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

namespace WindowsPhonePanoramaApplication1.ViewModels.CaptureViewModel
{
    public class PictureViewModel : NotifyingObject
    {
        #region Constants

        public const string IsolatedStoragePath = "Pictures";

        #endregion

        #region Fields

        private readonly ObservableCollection<Picture> _pictures = new ObservableCollection<Picture>();

        #endregion

        #region Properties

        public ObservableCollection<Picture> Pictures
        {
            get { return _pictures; }
        }

        #endregion

        #region Operations

        private void LoadSampleImages()
        {
            var samplePicturesResource = new ResourceDictionary
            {
                Source = new Uri("/WindowsPhonePanoramaApplication1;component/SampleData/ImageSample.xaml", UriKind.Relative)
            };

            foreach (ResourcePicture resourcePicture in samplePicturesResource.Values)
            {
                _pictures.Add(resourcePicture);
            }
        }

    
        #endregion

        #region Singleton Pattern

        private PictureViewModel()
        {
            LoadSampleImages();

        
        }

        public static PictureViewModel InstantCurent = new PictureViewModel();

        #endregion
    }
}
