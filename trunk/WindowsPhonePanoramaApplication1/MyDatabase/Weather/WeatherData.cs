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

namespace WindowsPhonePanoramaApplication1.MyDatabase.Weather
{
    public class WeatherData
    {
        public DateTime? DateCreate { get; set; }

        public string LocationWOEID { get; set; }


        public string NameCity { get; set; }

        public Visibility IsContentGridVisibility { get; set; }
        public string LblCurrent_Text { get; set; }
        public string LblCurrent_conditions_Text { get; set; }


        public string ImgWeather1_Source { get; set; }


        public string ImgWeather2_Source { get; set; }


        public string ImgWeather3_Source { get; set; }



        public string LblForecast1_Text { get; set; }

        public string LblForecast1_conditions_Text { get; set; }

        public string LblForecast2_Text { get; set; }
        public string LblForecast2_conditions_Text { get; set; }
      
        





    }
}
