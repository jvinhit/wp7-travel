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
    public class ArticalListViewModel : ViewModelBase
    {
        public ObservableCollection<ArticalListView> listArtical { get; private set; }
        private ArticalListViewModel()
        {
            listArtical = new ObservableCollection<ArticalListView>();
            listArtical.Add(new ArticalListView() { Title = "TitleTest", Content = "Contentsssasdfakjsdfjkasdj;lasjfd;laslkdjf;alk;lfksjlkdfja;lsdjf;lajsdflajdfja;dfja;slfdja;skdjf;lasjdf;lajfd;laskdfjla;jflasjf;lasjdf;alsjdfa;lsjf;asljfs;lafjas;lfjaslfj;aslfdj", ImageUrl = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });
            listArtical.Add(new ArticalListView() { Title = "TitleTest", Content = "Contentsss", ImageUrl = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });
            listArtical.Add(new ArticalListView() { Title = "TitleTest", Content = "Contentsss", ImageUrl = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });
            listArtical.Add(new ArticalListView() { Title = "TitleTest", Content = "Contentsss", ImageUrl = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });
            listArtical.Add(new ArticalListView() { Title = "TitleTest", Content = "Contentsss", ImageUrl = new Uri("/Images/News/Sections/cafe.jpg", UriKind.Relative) });
       
        }
        public static ArticalListViewModel instance = new ArticalListViewModel();
        public void ToDetailPage(ArticalListView temp)
        {

        }

    }
}
