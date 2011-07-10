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
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace WindowsPhonePanoramaApplication1.View.CaptureView
{
    public class PictureSlideView : INotifyPropertyChanged
    {
        private int indexImageCurrent = 0;
        private BitmapSource imageSource = null;//PictureViewModel.InstantCurent.Pictures[indexImageCurrent].Source;



        public int IndexImageCurrent
        {
            get { return indexImageCurrent; }
            set
            {
                if (value != indexImageCurrent)
                {
                    indexImageCurrent = value;
                    NotifyPropertyChanged("IndexImageCurrent");
                }
            }
        }

        public BitmapSource ImageSource
        {
            get { return imageSource; }
            set
            {
                if (value != imageSource)
                {
                    imageSource = value;
                    NotifyPropertyChanged("ImageSource");
                }
            }
        }




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
