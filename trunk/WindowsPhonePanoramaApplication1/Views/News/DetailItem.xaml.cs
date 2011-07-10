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
using WindowsPhonePanoramaApplication1.Models.News;
using Microsoft.Phone.Shell;
using WindowsPhonePanoramaApplication1.Models.CaptureViewModel;
using System.Windows.Media.Imaging;
using WindowsPhonePanoramaApplication1.Models.GoogleViewModel;

namespace MainTravel
{
    public partial class DetailItem : PhoneApplicationPage
    {
    
        public DetailItem()
        {
            InitializeComponent();
            this.DataContext = NewsDetailViewModel.instance;
            this.Loaded += new RoutedEventHandler(DetailItem_Loaded);
     
        }

        void DetailItem_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationBarIconButton temp = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
            UpdateAppBar(temp);
        }
        private void UpdateAppBar(ApplicationBarIconButton buttonFavorite)
        {
         
            if (NewsDetailViewModel.instance.IsFavorite == true)
            {

                buttonFavorite.IconUri = new Uri("/Resources/Icons/icon_favourite.png", UriKind.Relative);
            }
            else
            {

                buttonFavorite.IconUri = new Uri("/Resources/AppBar/App_Favourite.png", UriKind.Relative);
            }
        }


       

        private void HomeReturn_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void Favourite_Click(object sender, EventArgs e)
        {
            ApplicationBarIconButton buttonFavorite = (ApplicationBarIconButton)sender;
            NewsDetailViewModel.instance.IsFavorite = !NewsDetailViewModel.instance.IsFavorite;
            UpdateAppBar(buttonFavorite);
        }

        private void NextPage_Click(object sender, EventArgs e)
        {

        }

        private void PrePage_Click(object sender, EventArgs e)
        {

        }

        private void ShowComment_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/News/ListComment.xaml", UriKind.Relative));
        }

        private void ShowPictures_Click(object sender, EventArgs e)
        {

            PictureViewViewModel.instance.listImage = NewsDetailViewModel.instance.listImage;
            //PictureViewViewModel.instance.listImage = PictureRepository.Instance.Pictures;
            this.NavigationService.Navigate(new Uri("/Views/Capture/PictureView.xaml", UriKind.Relative));
        }

        private void ShowVideo_Click(object sender, EventArgs e)
        {

        }

        private void ShowPlace_Click(object sender, EventArgs e)
        {
            GoogleViewModel.InstanceCurrent._pushpins = new System.Collections.ObjectModel.ObservableCollection<TravelObject.PlaceObject>();
            GoogleViewModel.InstanceCurrent._pushpins.Add(NewsDetailViewModel.instance);
            this.NavigationService.Navigate(new Uri("/Views/GoogleMaps/GoogleMaps.xaml", UriKind.Relative));

        }

    }
}
