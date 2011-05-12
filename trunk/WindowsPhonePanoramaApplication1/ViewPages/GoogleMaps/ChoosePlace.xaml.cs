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
using WindowsPhonePanoramaApplication1.ViewModels.GoogleViewModel;

namespace WindowsPhonePanoramaApplication1.ViewPages.GoogleMaps
{
    public partial class ChoosePlace : PhoneApplicationPage
    {
        
        public ChoosePlace()
        {
            InitializeComponent();
            this.DataContext = GoogleViewModel.InstanceCurrent.placeKind;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}