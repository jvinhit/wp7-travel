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
using System.Collections.Generic;

namespace TravelObject
{
    public class NewsObject
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }

        public string Adress;
        public string ID;
        public string Article;
        public string ShortInformation;
        public string FullInformation;
        public List<byte[]> ImageStreams;
    }
}
