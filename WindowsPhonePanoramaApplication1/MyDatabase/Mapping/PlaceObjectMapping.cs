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
using System.Collections.Generic;

namespace WindowsPhonePanoramaApplication1.MyDatabase.Mapping
{
    public static class PlaceObjectMapping
    {

        public static void GetPlaceObject(ref PlaceObject _temCafe, WindowsPhonePanoramaApplication1.MyDatabase.ViewData.PlaceObjectViewData temp)
        {

            _temCafe.Address = temp.Address;
            _temCafe.Article = temp.Article;
            _temCafe.background = temp.background;
            _temCafe.Content = temp.Content;
            _temCafe.DatePost = (DateTime)temp.DatePost;
            _temCafe.geoCoor = new System.Device.Location.GeoCoordinate(temp.lattitude, temp.longtitude);
            _temCafe.IsFavorite = (bool)temp.IsFavorite;
            _temCafe.LinkYoutube = new Uri(temp.LinkYoutube, UriKind.RelativeOrAbsolute);

            _temCafe.ListComment = new System.Collections.ObjectModel.ObservableCollection<ItemComment>();
            foreach (ItemComment tempString in temp.ListComment)
            {

                _temCafe.ListComment.Add(tempString);
            }


            _temCafe.NameAuthor = temp.NameAuthor;
            _temCafe.RatingLevel = (int)temp.RatingLevel;
            _temCafe.ShorDescription = temp.ShorDescription;
            _temCafe.Title = temp.Title;
            _temCafe.ZoomLevel = temp.ZoomLevel;


            BitmapImage bitmap = new BitmapImage();
            bitmap = WP7Shared.ImageUtilitys.GetBitmapImageFromArrayByte(temp.ImageUrl);

            _temCafe.ImageMain = bitmap;
            _temCafe.listImage = new System.Collections.ObjectModel.ObservableCollection<BitmapImage>();
            foreach (byte[] tempIndex in temp.listImage)
            {
                BitmapImage t = new BitmapImage();
                t = WP7Shared.ImageUtilitys.GetBitmapImageFromArrayByte(tempIndex);
                _temCafe.listImage.Add(t);
            }

        }
        public static ItemComment convertItemCommnet(WcfService1.ItemComment data)
        {
            ItemComment result = new ItemComment();
            result.Author = data.Author;
            result.CommentString = data.CommentString;
            result.DataPost = (DateTime)data.DataPost;

            return result;
        }
        public static void GetPlaceObject(ref PlaceObject _temCafe, WcfService1.PlaceObjectViewData temp)
        {

            _temCafe.Address = temp.Address;
            _temCafe.Article = temp.Article;
            _temCafe.background = temp.background;
            _temCafe.Content = temp.Content;
            try
            {
                _temCafe.DatePost = (DateTime)temp.DatePost;
            }
            catch (InvalidOperationException e)
            {

            }
            _temCafe.geoCoor = new System.Device.Location.GeoCoordinate((double)temp.lattitude, (double)temp.longtitude);

            _temCafe.IsFavorite = (bool)temp.IsFavorite;
            try
            {
                _temCafe.LinkYoutube = new Uri(temp.LinkYoutube, UriKind.RelativeOrAbsolute);
            }
            catch (ArgumentNullException e)
            {
                _temCafe.LinkYoutube = null;
            }

            _temCafe.ListComment = new System.Collections.ObjectModel.ObservableCollection<ItemComment>();
            foreach (WcfService1.ItemComment tempString in temp.ListComment)
            {

                _temCafe.ListComment.Add(convertItemCommnet(tempString));
            }


            _temCafe.NameAuthor = temp.NameAuthor;
            _temCafe.RatingLevel = (int)temp.RatingLevel;
            _temCafe.ShorDescription = temp.ShorDescription;
            _temCafe.Title = temp.Title;
            _temCafe.ZoomLevel = temp.ZoomLevel;


            BitmapImage bitmap = new BitmapImage();


            bitmap = WP7Shared.ImageUtilitys.GetBitmapImageFromArrayByte(temp.ImageUrl);

            _temCafe.NameImageMain = Guid.NewGuid().ToString();
            //_temCafe.ImageMain = bitmap;


            _temCafe.listImageName = new System.Collections.ObjectModel.ObservableCollection<String>();
            //_temCafe.listImage = new System.Collections.ObjectModel.ObservableCollection<BitmapImage>();
            foreach (byte[] tempIndex in temp.listImage)
            {
                BitmapImage t = new BitmapImage();
                String temp1 = Guid.NewGuid().ToString();
                t = WP7Shared.ImageUtilitys.GetBitmapImageFromArrayByte(tempIndex);
                //_temCafe.listImage.Add(t);
                _temCafe.listImageName.Add(temp1);
            }

        }

        public static PlaceDB getPlaceDB(WcfService1.PlaceObjectViewData temp)
        {
            PlaceDB _Object = new PlaceDB();
            _Object.Address = temp.Address;
            _Object.Article = temp.Article;
            _Object.background = temp.background;
            _Object.Content = temp.Content;
            _Object.IdObject = temp.IdObject;
            if( temp.Article == "1")
                _Object.Icon = "/Images/ImageForPoint/Coffee.png";
            else 
                _Object.Icon = "/Images/ImageForPoint/hotel1star.png";

            if (temp.DatePost != null)
                _Object.DatePost = DateTime.Parse(temp.DatePost.ToString());
            _Object.geoCoor = new System.Device.Location.GeoCoordinate((double)temp.lattitude, (double)temp.longtitude);
            _Object.IsFavorite = (bool)temp.IsFavorite;
            try
            {
                _Object.LinkYoutube = temp.LinkYoutube.ToString();
            }
            catch (NullReferenceException e)
            {
                _Object.LinkYoutube = null;
            }


           
            _Object.ListComment = new List<ItemComment>();



            foreach (WcfService1.ItemComment tempString in temp.ListComment)
            {

                _Object.ListComment.Add(convertItemCommnet(tempString));
            }


            _Object.NameAuthor = temp.NameAuthor;
            _Object.RatingLevel = (int)temp.RatingLevel;
            _Object.ShorDescription = temp.ShorDescription;
            _Object.Title = temp.Title;
            _Object.ZoomLevel = temp.ZoomLevel;

            BitmapImage bitmap = new BitmapImage();


            bitmap = WP7Shared.ImageUtilitys.GetBitmapImageFromArrayByte(temp.ImageUrl);

            _Object.NameImageMain = Guid.NewGuid().ToString();
            WP7Shared.ImageUtilitys.SaveImage(_Object.NameImageMain, bitmap);

            _Object.listImageName = new List<string>();

            foreach (byte[] tempIndex in temp.listImage)
            {
                BitmapImage t = new BitmapImage();
                String temp1 = Guid.NewGuid().ToString();
                t = WP7Shared.ImageUtilitys.GetBitmapImageFromArrayByte(tempIndex);
                //_temCafe.listImage.Add(t);
                _Object.listImageName.Add(temp1);
                WP7Shared.ImageUtilitys.SaveImage(temp1, t);

            }

            return _Object;
        }
        public static PlaceObject getPlaceObjectFromPlaceDB(PlaceDB temp)
        {
            PlaceObject _Object = new PlaceObject();

            _Object.Address = temp.Address;
            _Object.Article = temp.Article;
            _Object.background = temp.background;
            _Object.Content = temp.Content;
            _Object.IdObject = temp.IdObject;

            _Object.Icon = new Uri(temp.Icon, UriKind.Relative);

            if (temp.DatePost != null)
                _Object.DatePost = DateTime.Parse(temp.DatePost.ToString());
            _Object.geoCoor = temp.geoCoor;
            _Object.IsFavorite = (bool)temp.IsFavorite;
            try
            {
                _Object.LinkYoutube = new Uri(temp.LinkYoutube.ToString(), UriKind.Relative);
            }
            catch (NullReferenceException e)
            {
                _Object.LinkYoutube = null;
            }



            _Object.ListComment = new System.Collections.ObjectModel.ObservableCollection<ItemComment>();



            foreach (ItemComment tempString in temp.ListComment)
            {

                _Object.ListComment.Add(tempString);
            }


            _Object.NameAuthor = temp.NameAuthor;
            _Object.RatingLevel = (int)temp.RatingLevel;
            _Object.ShorDescription = temp.ShorDescription;
            _Object.Title = temp.Title;
            _Object.ZoomLevel = temp.ZoomLevel;


            //_Object.NameImageMain = temp.NameImageMain;
            //_Object.listImageName = new List<string>();

            //foreach (String tempIndex in temp.listImageName)
            //{

            //    _Object.listImageName.Add(tempIndex);
            //}

            _Object.NameImageMain = temp.NameImageMain;
            _Object.ImageMain = WP7Shared.ImageUtilitys.ReadBitmapImage(temp.NameImageMain);

            _Object.listImageName = new System.Collections.ObjectModel.ObservableCollection<string>();
            _Object.listImage = new System.Collections.ObjectModel.ObservableCollection<BitmapImage>();
            foreach (string tempIndex in temp.listImageName)
            {
                BitmapImage t = new BitmapImage();
                _Object.listImageName.Add(tempIndex);
                t=WP7Shared.ImageUtilitys.ReadBitmapImage(tempIndex);
                _Object.listImage.Add(t);
            }

            return _Object;

        }
        public static WcfService1.ItemComment GetWcf_itemcomment(ItemComment input)
        {
            WcfService1.ItemComment result = new WcfService1.ItemComment();
            result.Author = input.Author;
            result.CommentString = input.CommentString;
            result.DataPost = input.DataPost;

            return result;
        }
    }
}
