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

namespace WindowsPhonePanoramaApplication1.ViewModels.News
{
    public class NewsPageViewModel : ViewModelBase
    {
        public ObservableCollection<SectionPageView> listSectionColum1 { get; private set; }
        public ObservableCollection<SectionPageView> listSectionColum2 { get; private set; }

        public ObservableCollection<VideoPageView> listVideo { get; private set; }


        private NewsPageViewModel()
        {
            listSectionColum1 = new ObservableCollection<SectionPageView>();
            listSectionColum2 = new ObservableCollection<SectionPageView>();

            listSectionColum1.Add(new SectionPageView() { DisplayName = "Cafe", ImageUri = new Uri("/Images/news/Sections/cafe.jpg", UriKind.Relative) });
            listSectionColum1.Add(new SectionPageView() { DisplayName = "Hotel", ImageUri = new Uri("/Images/news/Sections/hotel.jpg", UriKind.Relative) });
            listSectionColum1.Add(new SectionPageView() { DisplayName = "Restaurant", ImageUri = new Uri("/Images/news/Sections/restaurant.jpg", UriKind.Relative) });
            listSectionColum1.Add(new SectionPageView() { DisplayName = "Flights", ImageUri = new Uri("/Images/news/Sections/ticketAirPlane.jpg", UriKind.Relative) });
            listSectionColum1.Add(new SectionPageView() { DisplayName = "Car", ImageUri = new Uri("/Images/news/Sections/motorcycleRent.jpeg", UriKind.Relative) });
            listSectionColum1.Add(new SectionPageView() { DisplayName = "Tours", ImageUri = new Uri("/Images/news/Sections/tourism.jpg", UriKind.Relative) });

            listSectionColum2.Add(new SectionPageView() { DisplayName = "Review", ImageUri = new Uri("/Images/news/Sections/Review.jpg", UriKind.Relative) });
            listSectionColum2.Add(new SectionPageView() { DisplayName = "Top Place", ImageUri = new Uri("/Images/news/Sections/Top Travel.jpg", UriKind.Relative) });
            listSectionColum2.Add(new SectionPageView() { DisplayName = "Top Event", ImageUri = new Uri("/Images/news/Sections/TopEvent.png", UriKind.Relative) });
            listSectionColum2.Add(new SectionPageView() { DisplayName = "Tips Travel", ImageUri = new Uri("/Images/news/Sections/travel-tips.jpg", UriKind.Relative) });


            listVideo = new ObservableCollection<VideoPageView>();
            listVideo.Add(new VideoPageView() { ImageUri = new Uri("/Images/news/Sections/Review.jpg", UriKind.Relative), Title = "abcdsfadfsa", YouTubeUrl = new Uri("www.youtube.com/watch?v=WtzQY-G-6sU&feature=related", UriKind.Relative)});
            listVideo.Add(new VideoPageView() { ImageUri = new Uri("/Images/news/Sections/Review.jpg", UriKind.Relative), Title = "abcdsfadfsa", YouTubeUrl = new Uri("www.youtube.com/watch?v=WtzQY-G-6sU&feature=related", UriKind.Relative)});
            listVideo.Add(new VideoPageView() { ImageUri = new Uri("/Images/news/Sections/Review.jpg", UriKind.Relative), Title = "abcdsfadfsa", YouTubeUrl = new Uri("www.youtube.com/watch?v=WtzQY-G-6sU&feature=related", UriKind.Relative)});
            listVideo.Add(new VideoPageView() { ImageUri = new Uri("/Images/news/Sections/Review.jpg", UriKind.Relative), Title = "abcdsfadfsa", YouTubeUrl = new Uri("www.youtube.com/watch?v=WtzQY-G-6sU&feature=related", UriKind.Relative)});
            listVideo.Add(new VideoPageView() { ImageUri = new Uri("/Images/news/Sections/Review.jpg", UriKind.Relative), Title = "abcdsfadfsa", YouTubeUrl = new Uri("www.youtube.com/watch?v=WtzQY-G-6sU&feature=related", UriKind.Relative)});



        }
        public static NewsPageViewModel instance = new NewsPageViewModel();
    }
}
