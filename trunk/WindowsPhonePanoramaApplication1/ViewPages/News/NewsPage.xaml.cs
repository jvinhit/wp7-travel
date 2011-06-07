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

namespace WindowsPhonePanoramaApplication1.ViewPages.News
{
    public partial class NewsPage : PhoneApplicationPage
    {
        public NewsPage()
        {
            InitializeComponent();
            this.DataContext = NewsPageViewModel.instance;
        }

        private void ListBoxSections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            this.NavigationService.Navigate(new Uri("/ViewPages/News/ListArtical.xaml", UriKind.Relative));
        }

        private void HomeReturn_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

    }
}