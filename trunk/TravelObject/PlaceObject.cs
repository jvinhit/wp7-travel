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
using System.Device.Location;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace TravelObject
{
    public class ItemComment
    {
        public DateTime DataPost { get; set; }
        public String Author { get; set; }
        public String CommentString { get; set; }
    }

    public abstract class PlaceObject : INotifyPropertyChanged
    {

            private string title;
            public string Title {
                get{
                    return title;
                }
                set {
                    if (title == value) return;
                    title = value;
                    RaisePropertyChanged("Title");
                }
            }
            private int ratingLevel;

            public int RatingLevel
            {
                get { return ratingLevel; }
                set
                {
                    if (ratingLevel == value) return;
                    ratingLevel = value;
                    RaisePropertyChanged("RatingLevel");
                }
            }
          private bool isFavorite;

          public bool IsFavorite
            {
                get { return isFavorite; }
                set
                {
                    if (isFavorite == value) return;
                    isFavorite = value;
                    RaisePropertyChanged("IsFavorite");
                }
            }

    
      

   
        public string Article{ get; set; }
        public string IdObject { get; set; }
        public string IdKindPlace { get; set; }
        public GeoCoordinate geoCoor { get; set; }
        public double ZoomLevel { get; set; }
        public Uri Icon { get; set; }
        public string background { get; set; }
        public String Address { get; set; }
        public Uri ImageUrl { get; set; }
        public string Content { get; set; }
        public Uri LinkYoutube { get; set; }

        public string ShorDescription { get; set; }
        public ObservableCollection<ItemComment> ListComment { get; set; }
        public string NameAuthor { get; set; }
        
        public DateTime DatePost { get; set; }
        public ObservableCollection<BitmapSource> listImage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

      
    }
}
