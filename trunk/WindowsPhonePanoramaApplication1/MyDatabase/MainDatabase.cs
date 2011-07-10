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
using WindowsPhonePanoramaApplication1.MyDatabase;
using System.IO;
using TravelObject;
using System.Windows.Resources;
using System.Linq;

using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WindowsPhonePanoramaApplication1.MyDatabase.ViewData;
using System.IO.IsolatedStorage;


namespace WindowsPhonePanoramaApplication1.MyDatabase
{

    public static class MainDatabase
    {
        public static BitmapImage randomImage()
        {
            Random rd = new Random();
            Uri uri = new Uri("/WindowsPhonePanoramaApplication1;component/Images/SampleImages/" + rd.Next(1, 5).ToString() + ".jpg", UriKind.Relative);

            BitmapImage bimapimage=new BitmapImage(uri);
        
         
            return bimapimage;
        }
        public static List<BitmapImage> randomListImage()
        {
            List<BitmapImage> listImage = new List<BitmapImage>();
            for (int i = 0; i < 3; i++)
            {
                listImage.Add(randomImage());
            }
            return listImage;
        }
      

        public static Database mainDB;
        static string fileName = App.DATABASE_NAME;

        public static void CreateDataBase()
        {
            //var name = Guid.NewGuid().ToString();
            if (Database.DoesDatabaseExists(fileName) == false)
            {
                mainDB = Database.CreateDatabase(fileName);
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
            
            CreateTableWeather();
            CreateTablePlaceObject();
        }

     
        private static void CreateTableWeather()
        {
            //----------------------------weather
            mainDB.CreateTable<WeatherViewData>();
            WeatherViewData temp = new WeatherViewData() { NameCity = "Ho Chi Minh", LocationWOEID = "1252431", LblCurrent_Text = "Today" };
            temp.DateCreate = DateTime.Today;
            //Uri uri = new Uri("/WindowsPhonePanoramaApplication1;component/Images/WeatherImages/" + "result" + ".jpg", UriKind.Relative);
            string tempUri = "/WindowsPhonePanoramaApplication1;component/Images/WeatherImages/" + "result" + ".png";
            temp.ImgWeather1_Source = tempUri;
            temp.ImgWeather2_Source = tempUri;
            temp.ImgWeather3_Source = tempUri;
            temp.IsContentGridVisibility = Visibility.Visible;
            temp.LblCurrent_conditions_Text = temp.LblForecast1_conditions_Text = temp.LblForecast1_Text = temp.LblForecast2_conditions_Text = temp.LblForecast2_Text = "need update";

            mainDB.Table<WeatherViewData>().Add(temp);
            mainDB.Save();
        }

        private static TravelServiceClient proxy;
        private static void CreateTablePlaceObject()
        {
            proxy = new TravelServiceClient();

            proxy.GetAllLocationInDbCompleted += new EventHandler<GetAllLocationInDbCompletedEventArgs>(proxy_GetAllLocationInDbCompleted);
            proxy.GetAllLocationInDbAsync();

            //proxy = new TravelDatabaseClient();
            //proxy.GetAllNewsCompleted += new EventHandler<GetAllNewsCompletedEventArgs>(travelDb_GetAllNewsCompleted);
            //proxy.GetAllNewsAsync();



        }

        static void proxy_GetAllLocationInDbCompleted(object sender, GetAllLocationInDbCompletedEventArgs e)
        {
            WcfTravelService.Models.Travel_Location[] listResult = e.Result;
            int a = listResult.ToList<WcfTravelService.Models.Travel_Location>().Count;
            MessageBox.Show(a.ToString());
        }

 
  
    }
}
