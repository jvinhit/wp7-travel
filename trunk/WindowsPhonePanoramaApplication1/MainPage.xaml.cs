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
using WindowsPhonePanoramaApplication1.MyDatabase;

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
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
            // create database **Very Importance**
            MainDatabase.CreateDataBase();





        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           // MessageBox.Show(((Image)sender).Name.ToString());
            this.NavigationService.Navigate(new Uri(((Image)sender).Tag.ToString(), UriKind.Relative));
            //EnumsFunction Text = EnumsFunction.WeatherFunc   ;
            //switch (Text)
            //{
            //    case EnumsFunction.WeatherFunc:
                     
            //        break;

            //}
        }
    }
}