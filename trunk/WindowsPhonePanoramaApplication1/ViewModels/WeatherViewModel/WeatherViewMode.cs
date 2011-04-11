using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Windows.Media.Imaging;

using System.Collections.Generic;
using System.Linq;

using Microsoft.Phone.Controls;


namespace WindowsPhonePanoramaApplication1
{
    public class WeatherViewMode : ViewModelBase
    {
        public ObservableCollection<WeatherView> ListWeatherInstance { get; private set; }
        private WeatherViewMode()
        {
            ListWeatherInstance = new ObservableCollection<WeatherView>();
            ListWeatherInstance.Add(new WeatherView() { NameCity = "Ho Chi Minh", LocationWOEID = "1252431",LblCurrent_Text="Today" });
            
        }
        public static WeatherViewMode weatherInstance = new WeatherViewMode();





        public void UpdateWeather()
        {
            WebClient wc1 = new WebClient();
            wc1.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc1_DownloadStringCompleted);
            Uri stringTemp = new Uri(string.Format("http://xml.weather.yahoo.com/forecastrss?w={0}&u=c", WeatherViewMode.weatherInstance.ListWeatherInstance[0].LocationWOEID));
            wc1.DownloadStringAsync(stringTemp);
        }
        private void wc1_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                //http://xml.weather.yahoo.com/forecastrss?p=NOXX0035&u=c

                XDocument doc = new XDocument();
                doc = XDocument.Parse(e.Result);

                /*
                //string title1 = doc.Descendants("channel").First().Descendants("title").First().Value;
                //string title2 = doc.Descendants("channel").First().Descendants("item").First().Descendants("title").First().Value;

                foreach (XElement element in doc.Descendants("channel").Nodes())
                {
                    if (element.ToString().Contains("<yweather:location"))
                    {
                        //<yweather:location city="Stavanger" region="" country="NO"/>

                        string city = element.Attribute("city").Value;
                        string country = element.Attribute("country").Value;
                        break;
                    }
                }
                */

                bool forecastTomorrow = true;

                foreach (XElement element in doc.Descendants("channel").First().Descendants("item").Nodes())
                {
                    //<yweather:condition  text="Cloudy" code="26" temp="6"  date="Mon, 22 Mar 2010 8:20 pm CET" />
                    //<yweather:forecast day="Mon" date="22 Mar 2010" low="3" high="6" text="Light Rain" code="11" />
                    //<yweather:forecast day="Tue" date="23 Mar 2010" low="2" high="6" text="Showers" code="11" />

                    if (element.ToString().Contains("<yweather:condition"))
                    {
                        //                ContentGrid.Visibility = Visibility.Visible;
                        weatherInstance.ListWeatherInstance[0].IsContentGridVisibility = Visibility.Visible;

                        string conditions = element.Attribute("text").Value;
                        string temp = element.Attribute("temp").Value;
                        string code = element.Attribute("code").Value;

                        int weatherCode = Convert.ToInt16(code);
                        string imageName = weatherImage(weatherCode);

                        Uri uri = new Uri("/WindowsPhonePanoramaApplication1;component/Images/WeatherImages/" + imageName + ".png", UriKind.Relative);
                        ImageSource img = new BitmapImage(uri);
                        //imgWeather1.Source = img;
                        weatherInstance.ListWeatherInstance[0].ImgWeather1_Source = img;

                        weatherInstance.ListWeatherInstance[0].LblCurrent_conditions_Text = conditions + ", " + temp + "°C";
                    }
                    else if (element.ToString().Contains("<yweather:forecast"))
                    {
                        string day = element.Attribute("day").Value;
                        string conditions = element.Attribute("text").Value;
                        string tempLow = element.Attribute("low").Value;
                        string tempHigh = element.Attribute("high").Value;
                        string code = element.Attribute("code").Value;

                        int weatherCode = Convert.ToInt16(code);
                        string imageName = weatherImage(weatherCode);

                        Uri uri = new Uri("/WindowsPhonePanoramaApplication1;component/Images/WeatherImages/" + imageName + ".png", UriKind.Relative);
                        ImageSource img = new BitmapImage(uri);

                        if (forecastTomorrow)
                        {
                            //lblForecast1.Text = "Forecast: " + day;
                            weatherInstance.ListWeatherInstance[0].LblForecast1_Text = "Forecast: " + day;

                            //lblForecast1_conditions.Text = conditions + ", " + tempLow + "-" + tempHigh + "°C";
                            weatherInstance.ListWeatherInstance[0].LblForecast1_conditions_Text = String.Format("{0}, {1}-{2}°C", conditions, tempLow, tempHigh);

                            //imgWeather2.Source = img;
                            weatherInstance.ListWeatherInstance[0].ImgWeather2_Source = img;
                            forecastTomorrow = false;
                        }
                        else
                        {
                            //lblForecast2.Text = "Forecast: " + day;
                            //lblForecast2_conditions.Text = conditions + ", " + tempLow + "-" + tempHigh + "°C";
                            //imgWeather3.Source = img;
                            weatherInstance.ListWeatherInstance[0].LblForecast2_Text = "Forecast: " + day; ;
                            weatherInstance.ListWeatherInstance[0].LblForecast2_conditions_Text = String.Format("{0}, {1}-{2}°C", conditions, tempLow, tempHigh);
                            weatherInstance.ListWeatherInstance[0].ImgWeather3_Source = img;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static string weatherImage(int weatherCode)
        {
            string result = "";
            try
            {
                string dayOrNight = "";

                if (DateTime.Now.Hour < 8 || DateTime.Now.Hour > 20)
                    dayOrNight = "n";
                else
                    dayOrNight = "d";

                if (weatherCode < 5 || weatherCode == 17 || weatherCode == 35)
                    result = "1d";
                else if (weatherCode == 5)
                    result = "5d";
                else if (weatherCode == 6 || weatherCode == 7 || weatherCode == 18)
                    result = "18n";
                else if (weatherCode == 8 || weatherCode == 9)
                    result = "8n";
                else if (weatherCode == 10 || weatherCode == 12 || weatherCode == 40)
                    result = "12d";
                else if (weatherCode == 11)
                    result = "11n";
                else if (weatherCode == 13 || weatherCode == 14 || weatherCode == 16)
                    result = "14d";
                else if (weatherCode == 15 || weatherCode == 25)
                    result = "15n";
                else if (weatherCode == 16 || weatherCode == 41 || weatherCode == 42 || weatherCode == 43 || weatherCode == 46)
                    result = "16d";
                else if (weatherCode == 19 || weatherCode == 20 || weatherCode == 21 || weatherCode == 22)
                    result = "19" + dayOrNight;
                else if (weatherCode == 23 || weatherCode == 24)
                    result = "23d";
                else if (weatherCode == 26)
                    result = "26n";
                else if (weatherCode == 27 || weatherCode == 28 || weatherCode == 29 || weatherCode == 30)
                    result = "27" + dayOrNight;
                else if (weatherCode == 31 || weatherCode == 32 || weatherCode == 36)
                    result = "31" + dayOrNight;
                else if (weatherCode == 33 || weatherCode == 34)
                    result = "31" + dayOrNight;
                else if (weatherCode == 37 || weatherCode == 38 || weatherCode == 47)
                    result = "37" + dayOrNight;
                else if (weatherCode == 39 || weatherCode == 37 || weatherCode == 45)
                    result = "39" + dayOrNight;
                else if (weatherCode == 44)
                    result = "44d";
                else if (weatherCode == 48)
                    result = "48" + dayOrNight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return result;
        }

        public static void UpdatePlace(string LocationWOEID, string NameCity)
        {
            weatherInstance.ListWeatherInstance[0].LocationWOEID = LocationWOEID;
            weatherInstance.ListWeatherInstance[0].NameCity = NameCity;
            
        }

    }
}
