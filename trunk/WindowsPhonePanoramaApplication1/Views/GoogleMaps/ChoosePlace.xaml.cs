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
using WindowsPhonePanoramaApplication1.Models.GoogleViewModel;
using System.Collections.ObjectModel;
using TravelObject;
using System.Device.Location;

namespace WindowsPhonePanoramaApplication1.Views.GoogleMaps
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
            ObservableCollection<PlaceObject> listCoffee = new ObservableCollection<PlaceObject>();
            GoogleViewModel.InstanceCurrent._pushpins.Clear();
            //listCoffee.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7669, 106.6918), DatePost = new DateTime(), RatingLevel = 2, NameAuthor = "Me", ShorDescription = "thongasdfasfa;sdfja;", Title = "TitleTest", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageMain = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });
            //listCoffee.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7639, 106.6933), DatePost = new DateTime(), RatingLevel = 2, NameAuthor = "Me", ShorDescription = "thongasdfasfa;sdfja;", Title = "TitleTest", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageMain = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });
            //listCoffee.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7629, 106.6928), DatePost = new DateTime(), RatingLevel = 2, NameAuthor = "Me", ShorDescription = "thongasdfasfa;sdfja;", Title = "TitleTest", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageMain = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });
            //listCoffee.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7619, 106.6938), DatePost = new DateTime(), RatingLevel = 2, NameAuthor = "Me", ShorDescription = "thongasdfasfa;sdfja;", Title = "TitleTest", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageMain = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });
            //listCoffee.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7692, 106.6938), DatePost = new DateTime(), RatingLevel = 2, NameAuthor = "Me", ShorDescription = "thongasdfasfa;sdfja;", Title = "TitleTest", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageMain = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });


            
            foreach (var tempIndex in listCoffee.ToList<PlaceObject>())
            {
                GoogleViewModel.InstanceCurrent._pushpins.Add(tempIndex);
            }
            NavigationService.GoBack();
        }
    }
}