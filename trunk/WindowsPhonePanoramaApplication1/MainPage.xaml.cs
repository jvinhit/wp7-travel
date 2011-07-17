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
using WindowsPhonePanoramaApplication1.MyDatabase;
using System.ComponentModel;
using System.Threading;
using Microsoft.Phone.Tasks;
using System.IO.IsolatedStorage;
using WindowsPhonePanoramaApplication1.Models.News;
using TravelObject;
using SilverlightPhoneDatabase;

namespace WindowsPhonePanoramaApplication1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
            IsolatedStorageSettings.ApplicationSettings["Username"] = "";

        }

        void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            throw new NotImplementedException();
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                ItemViewModel2 temp = ((System.Windows.Controls.Primitives.Selector)(sender)).SelectedItem as ItemViewModel2;
                String linkNavegation = temp.TagLink;
                this.NavigationService.Navigate(new Uri(linkNavegation, UriKind.Relative));
            }
            Functions.SelectedIndex = -1;
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            App.ViewModel.updateRss();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Rss_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
   
        }

        private void Rss_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                NewsDetailViewModel.instance = e.AddedItems[0] as PlaceObject;
                this.NavigationService.Navigate(new Uri("/Views/News/DetailItem.xaml", UriKind.Relative));
            }
            Rss.SelectedIndex = -1;

        }
        public static Database mainDB;
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            _performanceProgressBar.IsIndeterminate = true;

            Database.DeleteDatabase(App.DATABASE_NAME);
            //mainDB.Table<PlaceDB>().Clear();
            //mainDB.Save();

            MyDatabase.MainDatabase.CreateDataBase();
            MyDatabase.MainDatabase.UpdateDB();
            App.ViewModel.updateRss();
            System.Threading.Thread.Sleep(500);
            _performanceProgressBar.IsIndeterminate = false;
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {

        }
   
    }
}