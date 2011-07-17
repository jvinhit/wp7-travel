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
using TravelObject;
using System.Windows.Media.Imaging;
using System.IO;

namespace WindowsPhonePanoramaApplication1.MyDatabase.ViewData
{
    public class PlaceObjectViewData
    {

        private string title;
        private int ratingLevel;
        private bool? isFavorite;
        public string Article { get; set; }
        public string IdObject { get; set; }

        public double lattitude { get; set; }
        public double longtitude { get; set; }
        public double ZoomLevel { get; set; }
        public String Icon { get; set; }
        public string background { get; set; }
        public String Address { get; set; }
        public byte[] ImageUrl { get; set; }
        public string Content { get; set; }
        public String LinkYoutube { get; set; }
        public string ShorDescription { get; set; }
        public List<ItemComment> ListComment { get; set; }
        public string NameAuthor { get; set; }
        public DateTime? DatePost { get; set; }
        public List<byte[]> listImage { get; set; }
        public string Title { get; set; }
        public int? RatingLevel { get; set; }
        public bool? IsFavorite { get; set; }

        public PlaceObjectViewData()
        {
            // TODO: Complete member initialization
        }
    }
}
