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
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;

namespace WindowsPhonePanoramaApplication1
{
    public class ModifyPlaceViewModel:ViewModelBase
    {
        public ObservableCollection<PlaceMode> Items1 { get; private set; }
        private ModifyPlaceViewModel()
        {
            this.Items1 = new ObservableCollection<PlaceMode>();
        }

        public static ModifyPlaceViewModel instanceCurrent = new ModifyPlaceViewModel();

        public void FindPlace(string stringPlace)
        {
            WebClient wc1 = new WebClient();
            wc1.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc1_DownloadStringCompleted);

            Uri stringTemp = new Uri(string.Format("http://where.yahooapis.com/geocode?location={0}", stringPlace));
            wc1.DownloadStringAsync(stringTemp);
        }


        private void wc1_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                //http://xml.weather.yahoo.com/forecastrss?p=NOXX0035&u=c

                this.Items1.Clear();


                //XDocument doc = new XDocument();
                //doc = XDocument.Parse(e.Result);



                //XElement ele = XElement.Load(e.Result);
                //XElement ele = new XElement(doc.Elements());
                XElement ele = XElement.Parse(e.Result);

                XElement[] datasource = null;
                var numResult = (IEnumerable<XElement>)null;

                numResult = from item in ele.Descendants("Found")
                            select item;

                int numberResult = int.Parse(numResult.First().Value.Trim());

                var citiArray = (IEnumerable<XElement>)null;
                citiArray = from item in ele.Descendants(PlaceMode.listKeyXML[0])
                            select item;
                var countryArray = (IEnumerable<XElement>)null;
                countryArray = from item in ele.Descendants(PlaceMode.listKeyXML[1])
                               select item;

                var woeidArray = (IEnumerable<XElement>)null;
                woeidArray = from item in ele.Descendants(PlaceMode.listKeyXML[2])
                             select item;

                for (int i = 0; i < numberResult; i++)
                {
                    this.Items1.Add(new PlaceMode() { City = citiArray.ToList()[i].Value, Country = countryArray.ToList()[i].Value, Woeid = woeidArray.ToList()[i].Value });
                }

                woeidArray.ToList().Clear();
                citiArray.ToList().Clear();
                countryArray.ToList().Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public void UpdatePlace(string LocationWOEID, string NameCity)
        {
            WeatherViewMode.UpdatePlace(LocationWOEID, NameCity);
        }






    }
}
