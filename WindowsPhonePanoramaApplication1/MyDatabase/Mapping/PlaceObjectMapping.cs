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
using TravelObject;
using System.Windows.Media.Imaging;

namespace WindowsPhonePanoramaApplication1.MyDatabase.Mapping
{
    public static class PlaceObjectMapping
    {
  
        public static void GetPlaceObject(ref PlaceObject _temCafe, WindowsPhonePanoramaApplication1.MyDatabase.ViewData.PlaceObjectViewData temp)
        {
     
            _temCafe.Address        = temp.Address    ;   
            _temCafe.Article        = temp.Article       ;
            _temCafe.background     = temp.background    ;
            _temCafe.Content        = temp.Content       ;
            _temCafe.DatePost=temp.DatePost;
            _temCafe.geoCoor=new System.Device.Location.GeoCoordinate(temp.lattitude,temp.longtitude);
            _temCafe.IsFavorite=temp.IsFavorite;
            _temCafe.LinkYoutube=new Uri(temp.LinkYoutube,UriKind.RelativeOrAbsolute);

            _temCafe.ListComment = new System.Collections.ObjectModel.ObservableCollection<ItemComment>();
            foreach(ItemComment tempString in temp.ListComment)
            {
               
                _temCafe.ListComment.Add(tempString);
            }

            
            _temCafe.NameAuthor = temp.NameAuthor;
            _temCafe.RatingLevel = temp.RatingLevel;
            _temCafe.ShorDescription = temp.ShorDescription;
            _temCafe.Title = temp.Title;
            _temCafe.ZoomLevel = temp.ZoomLevel;


            BitmapImage bitmap=new BitmapImage();
            bitmap=WP7Shared.ImageUtilitys.GetBitmapImageFromArrayByte(temp.ImageUrl);

            _temCafe.ImageMain = bitmap;
            _temCafe.listImage = new System.Collections.ObjectModel.ObservableCollection<BitmapImage>();
            foreach (byte[] tempIndex in temp.listImage)
            {
                

                BitmapImage t = new BitmapImage();
                t = WP7Shared.ImageUtilitys.GetBitmapImageFromArrayByte(tempIndex);
                _temCafe.listImage.Add(t);
            }

        }

    }
}
