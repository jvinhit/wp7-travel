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
using System.Device.Location;
using System.ComponentModel;
using System.Collections.Generic;

namespace TravelObject
{
    public class PlaceDB
    {
        private string title;
        private int ratingLevel;
        private bool isFavorite;
        public string Article { get; set; }
        public string IdObject { get; set; }
        public string IdKindPlace { get; set; }
        public GeoCoordinate geoCoor { get; set; }
        public double ZoomLevel { get; set; }
        public String Icon { get; set; }
        public string background { get; set; }
        public String Address { get; set; }

        public String NameImageMain { get; set; }
        public string Content { get; set; }
        public String LinkYoutube { get; set; }
        public string ShorDescription { get; set; }
        public List<ItemComment> ListComment { get; set; }
        public string NameAuthor { get; set; }
        public DateTime DatePost { get; set; }
        public int numberImageForIntro { get; set; }
        public List<String> listImageName { get; set; }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title == value) return;
                title = value;
        
            }
        }

        public int RatingLevel
        {
            get { return ratingLevel; }
            set
            {
                if (ratingLevel == value) return;
                ratingLevel = value;
           
            }
        }


        public bool IsFavorite
        {
            get { return isFavorite; }
            set
            {
                if (isFavorite == value) return;
                isFavorite = value;
             
            }
        }
    }
}
