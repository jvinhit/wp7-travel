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
using WindowsPhonePanoramaApplication1.View.News;
using TravelObject;

namespace WindowsPhonePanoramaApplication1.Views.News
{
    public partial class ListComment : PhoneApplicationPage
    {
        public ListComment()
        {
            InitializeComponent();
            this.DataContext = NewsDetailViewModel.instance;
        }

        private void CommentButton(object sender, RoutedEventArgs e)
        {
            //update
            boxComment.Visibility = Visibility.Collapsed;

            NewsDetailViewModel.instance.ListComment.Add(new ItemComment() { Author = "Me", CommentString = txtComment.Text.Trim(), DataPost = DateTime.Now });
        }

        private void ShowComment(object sender, EventArgs e)
        {
            boxComment.Visibility = Visibility.Visible;
            txtComment.Text = "";
        }

    }
}