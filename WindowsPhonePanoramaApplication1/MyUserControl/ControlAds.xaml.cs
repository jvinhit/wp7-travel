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
using Microsoft.Phone.Tasks;

namespace WindowsPhonePanoramaApplication1.MyUserControl
{
    public partial class ControlAds : UserControl
    {
        public ControlAds()
        {
            
            //this.Loaded += new RoutedEventHandler(ControlAds_Loaded);
            InitializeComponent();
            if (App.IsShowAds == false)
                this.Visibility = Visibility.Collapsed;
            else
                this.Visibility = Visibility.Visible;
            
            
            

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var webBrowserTask = new WebBrowserTask
            {
                URL = "http://google.com"
            };

            webBrowserTask.Show();
        }

       
    }
}
