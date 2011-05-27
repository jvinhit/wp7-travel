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
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using WindowsPhonePanoramaApplication1.View.CaptureView;

namespace WindowsPhonePanoramaApplication1.ViewModels.CaptureViewModel
{
    public class PictureViewViewModel : NotifyingObject
    {
        public PictureSlideView pictures = new PictureSlideView();

        private int maxNumberImage = PictureRepository.Instance.Pictures.Count;
        public void NextImage()
        {

            if (instance.pictures.IndexImageCurrent == maxNumberImage - 1)
            {
                instance.pictures.IndexImageCurrent = 0;
            }
            else
                instance.pictures.IndexImageCurrent++;

            UpdateImage();

        }
        public void PreImage()
        {

            if (instance.pictures.IndexImageCurrent == 0)
            {
                instance.pictures.IndexImageCurrent = maxNumberImage - 1;
            }
            else
                instance.pictures.IndexImageCurrent--;

            UpdateImage();
        }
        void UpdateImage()
        {
            pictures.ImageSource = PictureRepository.Instance.Pictures[pictures.IndexImageCurrent].Source;
        }
        private PictureViewViewModel()
        {
            UpdateImage();
        }
        public static PictureViewViewModel instance = new PictureViewViewModel();
 
       
    }
}
