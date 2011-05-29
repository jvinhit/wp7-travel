﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace WindowsPhonePanoramaApplication1.View.News
{
    public class VideoPageView : INotifyPropertyChanged
    {
        public Uri Link
        {
            get { return YouTubeUrl; }
        }

        public string Title { get; set; }

        public string Content
        {
            get { return string.Empty; }
        }

        public Uri YouTubeUrl { get; set; }
      
        public Uri ImageUri { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
