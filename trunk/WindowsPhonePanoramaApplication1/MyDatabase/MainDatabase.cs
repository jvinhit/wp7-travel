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
using SilverlightPhoneDatabase;
using System.Windows.Media.Imaging;
using WindowsPhonePanoramaApplication1.MyDatabase.Weather;
using System.IO;


namespace WindowsPhonePanoramaApplication1.MyDatabase
{
    public static class MainDatabase
    {
        public static Database mainDB;
        static string fileName = "WP7.db";
        public static void CreateDataBase()
        {
            //var name = Guid.NewGuid().ToString();
            if (Database.DoesDatabaseExists(fileName) == false)
            {
                mainDB = Database.CreateDatabase(fileName);
                //mainDB.Save();
                // create table
                CreateTable();

            }
            else
            {
               
                mainDB = Database.OpenDatabase(fileName);
                mainDB.Save();
              
            }

            
           
        }
        static void CreateTable()
        {
            //----------------------------weather
         
            mainDB.CreateTable<WeatherData>();

            WeatherData temp = new WeatherData() { NameCity = "Ho Chi Minh", LocationWOEID = "1252431", LblCurrent_Text = "Today" };
            temp.DateCreate = DateTime.Today;
            //Uri uri = new Uri("/WindowsPhonePanoramaApplication1;component/Images/WeatherImages/" + "result" + ".jpg", UriKind.Relative);

            string tempUri = "/WindowsPhonePanoramaApplication1;component/Images/WeatherImages/" + "result" + ".jpg";
            temp.ImgWeather1_Source = tempUri;
            temp.ImgWeather2_Source = tempUri;
            temp.ImgWeather3_Source = tempUri;


            

            temp.IsContentGridVisibility = Visibility.Visible;
            temp.LblCurrent_conditions_Text = temp.LblForecast1_conditions_Text = temp.LblForecast1_Text = temp.LblForecast2_conditions_Text = temp.LblForecast2_Text = "need update";

            mainDB.Table<WeatherData>().Add(temp);
            mainDB.Save();

            
            //----------------------------googlemap
            //mainDB.CreateTable<GoogleMapView>();
            ////Microsoft.Phone.Controls.Maps.Map temp = null;
            //GoogleMapView tempMap = new GoogleMapView() {DateCreate=DateTime.Today,googlemap=null };
            //mainDB.Table<GoogleMapView>().Add(tempMap);
            //mainDB.Save();
        }




    }
}
