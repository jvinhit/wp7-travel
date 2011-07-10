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
using WindowsPhonePanoramaApplication1.Models.CaptureViewModel;
using TravelObject;
using System.Device.Location;
using System.Windows.Media.Imaging;
using SilverlightPhoneDatabase;
using System.Linq;
using WindowsPhonePanoramaApplication1.MyDatabase.Mapping;

namespace WindowsPhonePanoramaApplication1.Models.News
{
    public class ArticalListViewModel : ViewModelBase
    {
        public ObservableCollection<PlaceObject> listArtical { get; private set; }

        private void LoadDataFromDatabase()
        {
            listArtical = new ObservableCollection<PlaceObject>();
            Database db = MyDatabase.MainDatabase.mainDB;



            var listPlaceObject = (from objectPlace in db.Table<WindowsPhonePanoramaApplication1.MyDatabase.ViewData.PlaceObjectViewData>() 
                                  select objectPlace);


            foreach (WindowsPhonePanoramaApplication1.MyDatabase.ViewData.PlaceObjectViewData temp 
                in listPlaceObject.ToList<WindowsPhonePanoramaApplication1.MyDatabase.ViewData.PlaceObjectViewData>())
            {
                PlaceObject tempPlace=new CafePlace();
                PlaceObjectMapping.GetPlaceObject(ref tempPlace, temp);
                listArtical.Add(tempPlace);
            }

        }


        private ArticalListViewModel()
        {
            //LoadDataFromDatabase();
            listArtical = new ObservableCollection<PlaceObject>();
            listArtical.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7669, 106.6918), DatePost = new DateTime(), RatingLevel = 2, NameAuthor = "Nam", ShorDescription = "Góc phố Huỳnh Thúc Kháng giao với Pasteur là một tọa điểm... ", Title = "cafe paris", Content = "Góc phố Huỳnh Thúc Kháng giao với Pasteur là một tọa điểm mới của Soho. Ngồi trên lầu nhìn xuống phố với dòng người qua lại, không ồn ào, không vộn vã, cảm giác như có 1 góc phố Hà Nội ở giữa Sài Gòn vậy. Vào Soho nhớ thưởng thức những món ngon nơi đây nhé! Thức uống có lẽ ngon và đặc biệt chính là cà phê hoặc capuchino, cocktail. Giá cả khá là mềm so với những quán khác, thức uống đắt nhất là cocktail 70k, còn lại dao động từ 27k - 50k là cùng. Vào Soho thích nhất là nhân viên quán rất thân thiện và nhiệt tình. Có khi ngồi cả buổi chiều, uống 1 ly cà phê nhưng nước trà lúc nào cũng uống miễn phí...thoải mái. ", ImageMain = new BitmapImage(new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative)) });
            //listArtical.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7639, 106.6933), DatePost = new DateTime(), RatingLevel = 5, NameAuthor = "Kevin", ShorDescription = "restaurant KXA...", Title = "restaurant KXA", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageMain = new Uri("/Images/News/Sections/hotel.jpg", UriKind.Relative) });
            //listArtical.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7629, 106.6928), DatePost = new DateTime(), RatingLevel = 1, NameAuthor = "Jason", ShorDescription = "cafe EKX", Title = "cafe EKX", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageMain = new Uri("/Images/News/Sections/Restaurant.jpg", UriKind.Relative) });
            //listArtical.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7619, 106.6938), DatePost = new DateTime(), RatingLevel = 2, NameAuthor = "Me", ShorDescription = "Hotel NewWorld...", Title = "Hotel NewWorld", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageMain = new Uri("/Images/News/Sections/ticketAirPlane.jpg", UriKind.Relative) });
            //listArtical.Add(new CafePlace() { IsFavorite = true, Address = "135 tran hung dao quan 1", geoCoor = new GeoCoordinate(10.7692, 106.6938), DatePost = new DateTime(), RatingLevel = 2, NameAuthor = "Me", ShorDescription = "cafe ISK...", Title = "cafe ISK", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageMain = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });

            //foreach (PlaceObject tempIndex in listArtical)
            //{
            //    tempIndex.ListComment = new ObservableCollection<ItemComment>();
            //    tempIndex.ListComment.Add(new ItemComment() { Author = "Kevin", DataPost = new DateTime(), CommentString = "i want to go there" });
            //    tempIndex.ListComment.Add(new ItemComment() { Author = "Jason", DataPost = new DateTime(), CommentString = "I like it" });
            //    tempIndex.ListComment.Add(new ItemComment() { Author = "Michal", DataPost = new DateTime(), CommentString = "Greate" });


            //    tempIndex.listImage = new ObservableCollection<BitmapImage>();
            //    //test please convert to bitmapsource class
            //    var samplePicturesResource = new ResourceDictionary
            //    {
            //        Source = new Uri("/WindowsPhonePanoramaApplication1;component/SampleData/ImageSample.xaml", UriKind.Relative)
            //    };

            //    foreach (ResourcePicture resourcePicture in samplePicturesResource.Values)
            //    {
            //        BitmapImage temp=new BitmapImage(resourcePicture.ResourceUri);
            //        tempIndex.listImage.Add(temp);
            //    }
            //}
        }
        public static ArticalListViewModel instance = new ArticalListViewModel();
        public void ToDetailPage(ItemsView temp)
        {

        }

    }
}
