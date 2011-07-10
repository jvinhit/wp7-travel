using System;
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
using AccessingWP7Devices.Assets.Controls;
using WindowsPhonePanoramaApplication1.Models.CaptureViewModel;
using WP7Shared;
using System.Device.Location;
using AccessingWP7Devices.Assets.Helpers;
using Microsoft.Phone.Controls.Maps;

namespace WindowsPhonePanoramaApplication1.Views.Capture
{
    public partial class CapturePicturePage : PhoneApplicationPage
    {

        public CapturePicturePage()
        {
            InitializeComponent();
        }
        internal const string ModelStateKey = "CapturePicturePage.Model";
        /// <value>Provides credentials for the map control.</value>
        private readonly CredentialsProvider _credentialsProvider = new ApplicationIdCredentialsProvider(App.BingId);
        private CapturedPictureViewModel Model
        {
            get
            {
                if (DataContext == null)
                {
                    var model = TransientState.Get<CapturedPictureViewModel>(ModelStateKey, false);
                    if (model == null)
                    {
                        model = new CapturedPictureViewModel();
                        TransientState.Set(ModelStateKey, model);
                    }

                    DataContext = model;
                }

                return DataContext as CapturedPictureViewModel;
            }
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (Model != null)
            {
                ResolvePictureAddress(Model);
            }

            base.OnNavigatedTo(e);
        }
        // application bar event
        private void ApplicationBarPictureList_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ApplicationBarSavePicture_Click(object sender, EventArgs e)
        {
            NotificationBox.Show(
                "Save picture",
                "Where would you like to save the picture?",
                SaveToPicturesHub,
                SaveToLocalStorage);
        }

        // private
        private void ResolvePictureAddress(CapturedPictureViewModel picture)
        {
            if (GpsHelper.Instance.Watcher.Status == GeoPositionStatus.Ready)
            {
                picture.Position = GpsHelper.Instance.Watcher.Position.Location;
                GeocodeHelper.ReverseGeocodeAddress(
                    Dispatcher,
                    _credentialsProvider,
                    picture.Position,
                    result => picture.Address = result.Address.FormattedAddress);
            }
            else
            {
                picture.Position = GeoCoordinate.Unknown;
            }
        }

        private NotificationBoxCommand SaveToLocalStorage
        {
            get
            {
                return new NotificationBoxCommand("Local Memory", () =>
                {
                    // Cache image in repository.
                    PictureRepository.Instance.Pictures.Add(Model);
                    PictureRepository.Instance.SaveToLocalStorage(Model, PictureRepository.IsolatedStoragePath);

                    NavigationService.GoBack();
                });
            }
        }

        private NotificationBoxCommand SaveToPicturesHub
        {
            get
            {
                return new NotificationBoxCommand("Library Picture", () =>
                {
                    PictureRepository.Instance.SaveToPicturesHub(Model);

                    NavigationService.GoBack();
                });
            }
        }


 

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

        }
        
    }
}