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
using WindowsPhonePanoramaApplication1.ViewModels.News;
using WindowsPhonePanoramaApplication1.View.News;
using TravelObject;

namespace WindowsPhonePanoramaApplication1.ViewPages.News
{
    public partial class ListArtical : PhoneApplicationPage
    {
        public ListArtical()
        {
            InitializeComponent();
            this.DataContext = ArticalListViewModel.instance;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                NewsDetailViewModel.instance = e.AddedItems[0] as PlaceObject;
                this.NavigationService.Navigate(new Uri("/ViewPages/News/DetailItem.xaml", UriKind.Relative));
            }
        }

        private void HomeReturn_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}