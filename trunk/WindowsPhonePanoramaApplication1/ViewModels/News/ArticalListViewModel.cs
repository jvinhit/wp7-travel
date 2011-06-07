using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using WindowsPhonePanoramaApplication1.View.News;
using System.Collections.ObjectModel;
using WindowsPhonePanoramaApplication1.ViewModels.CaptureViewModel;
using TravelObject;
using System.Device.Location;

namespace WindowsPhonePanoramaApplication1.ViewModels.News
{
    public class ArticalListViewModel : ViewModelBase
    {
        public ObservableCollection<PlaceObject> listArtical { get; private set; }
        private ArticalListViewModel()
        {
            listArtical = new ObservableCollection<PlaceObject>();
            listArtical.Add(new CafePlace() { IsFavorite = true, Address="135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7669, 106.6918), DatePost = new DateTime(), RatingLevel = 2, NameAuthor = "Me", ShorDescription = "thongasdfasfa;sdfja;", Title = "TitleTest", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageUrl = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });
            listArtical.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7639, 106.6933), DatePost = new DateTime(), RatingLevel = 2, NameAuthor = "Me", ShorDescription = "thongasdfasfa;sdfja;", Title = "TitleTest", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageUrl = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });
            listArtical.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7629, 106.6928), DatePost = new DateTime(), RatingLevel = 2, NameAuthor = "Me", ShorDescription = "thongasdfasfa;sdfja;", Title = "TitleTest", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageUrl = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });
            listArtical.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7619, 106.6938), DatePost = new DateTime(), RatingLevel = 2, NameAuthor = "Me", ShorDescription = "thongasdfasfa;sdfja;", Title = "TitleTest", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageUrl = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });
            listArtical.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7692, 106.6938), DatePost = new DateTime(), RatingLevel = 2, NameAuthor = "Me", ShorDescription = "thongasdfasfa;sdfja;", Title = "TitleTest", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageUrl = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });

            foreach (PlaceObject tempIndex in listArtical)
            {
                tempIndex.ListComment = new ObservableCollection<ItemComment>();
                tempIndex.ListComment.Add(new ItemComment() { Author = "safd", DataPost = new DateTime(), CommentString = "fasdfa" });
                tempIndex.ListComment.Add(new ItemComment() { Author = "safd", DataPost = new DateTime(), CommentString = "fasdfa" });
                tempIndex.ListComment.Add(new ItemComment() { Author = "safd", DataPost = new DateTime(), CommentString = "fasdfa" });


                tempIndex.listImage = new ObservableCollection<System.Windows.Media.Imaging.BitmapSource>();
                //test please convert to bitmapsource class
                var samplePicturesResource = new ResourceDictionary
                {
                    Source = new Uri("/WindowsPhonePanoramaApplication1;component/SampleData/ImageSample.xaml", UriKind.Relative)
                };

                foreach (ResourcePicture resourcePicture in samplePicturesResource.Values)
                {
                    tempIndex.listImage.Add(resourcePicture.Source);
                }
            }
        }
        public static ArticalListViewModel instance = new ArticalListViewModel();
        public void ToDetailPage(ItemsView temp)
        {

        }

    }
}
