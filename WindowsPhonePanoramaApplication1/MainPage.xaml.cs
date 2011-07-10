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

            //theme

        
    
            
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
            ItemViewModel2 temp = ((System.Windows.Controls.Primitives.Selector)(sender)).SelectedItem as ItemViewModel2;
            String linkNavegation = temp.TagLink;
            this.NavigationService.Navigate(new Uri(linkNavegation, UriKind.Relative));
        }
    }
}