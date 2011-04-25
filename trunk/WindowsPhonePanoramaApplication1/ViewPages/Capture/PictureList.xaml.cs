﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using WindowsPhonePanoramaApplication1.ViewModels.CaptureViewModel;
using Microsoft.Phone.Tasks;
using AccessingWP7Devices.Assets.Controls;
using WP7Shared;


namespace WindowsPhonePanoramaApplication1.ViewPages.Capture
{
    public partial class PictureList : PhoneApplicationPage
    {
        private readonly CameraCaptureTask _cameraTask;
        public PictureList()
        {
            InitializeComponent();
            this.DataContext = PictureRepository.Instance;

            // create camera
            // Initialize camera task
            _cameraTask = new CameraCaptureTask();
            _cameraTask.Completed += cameraTask_Completed;
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var capturedPicture = TransientState.Get<CapturedPictureViewModel>("CapturedPictureViewModel");
            if (capturedPicture != null)
            {
                TransientState.Set<CapturedPictureViewModel>(CapturePicturePage.ModelStateKey, capturedPicture);
                //NavigationService.Navigate<CapturePicturePage>();
                this.NavigationService.Navigate(new Uri("/ViewPages/Capture/CapturePicturePage.xaml", UriKind.Relative));



            }

            base.OnNavigatedTo(e);
        }


        private void cameraTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                // Get the image temp file from e.OriginalFileName.
                // Get the image temp stream from e.ChosenPhoto.
                // Don't keep either the temp stream or file name.
                var capturedPicture = new CapturedPictureViewModel(e.OriginalFileName, e.ChosenPhoto);
                //set mode for camera
                TransientState.Set("CapturedPictureViewModel", capturedPicture);
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            _cameraTask.Show();
        }
    }
}