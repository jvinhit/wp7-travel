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

namespace WindowsPhonePanoramaApplication1.Models.News
{
    public class NewsPageViewModel : ViewModelBase
    {
        public ObservableCollection<SectionPageView> listSectionColum1 { get; private set; }
        public ObservableCollection<SectionPageView> listSectionColum2 { get; private set; }



        private NewsPageViewModel()
        {
            listSectionColum1 = new ObservableCollection<SectionPageView>();
            //listSectionColum2 = new ObservableCollection<SectionPageView>();

            listSectionColum1.Add(new SectionPageView() { RatingLevel = 3, DisplayName = "Cafe", ImageUri = new Uri("/Images/news/Sections/icon_folder.png", UriKind.Relative) });
            listSectionColum1.Add(new SectionPageView() { RatingLevel = 3, DisplayName = "Hotel", ImageUri = new Uri("/Images/news/Sections/icon_folder.png", UriKind.Relative) });
            listSectionColum1.Add(new SectionPageView() { RatingLevel = 3, DisplayName = "Restaurant", ImageUri = new Uri("/Images/news/Sections/icon_folder.png", UriKind.Relative) });
            listSectionColum1.Add(new SectionPageView() { RatingLevel = 3, DisplayName = "Flights", ImageUri = new Uri("/Images/news/Sections/icon_folder.png", UriKind.Relative) });
            listSectionColum1.Add(new SectionPageView() { RatingLevel = 3, DisplayName = "Car", ImageUri = new Uri("/Images/news/Sections/icon_folder.png", UriKind.Relative) });
            listSectionColum1.Add(new SectionPageView() { RatingLevel = 3, DisplayName = "Tours", ImageUri = new Uri("/Images/news/Sections/icon_folder.png", UriKind.Relative) });

           

        }
        public static NewsPageViewModel instance = new NewsPageViewModel();
    }
}
