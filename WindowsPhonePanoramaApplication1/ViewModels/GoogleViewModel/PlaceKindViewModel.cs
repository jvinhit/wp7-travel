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
using System.Collections.ObjectModel;
using WindowsPhonePanoramaApplication1.View.GoogleView;

namespace WindowsPhonePanoramaApplication1.ViewModels.GoogleViewModel
{
    public class PlaceKindViewModel:ViewModelBase
    {
        public ObservableCollection<PlaceKindView> listPlaceKind { get; private set; }
        private PlaceKindViewModel()
        {
            listPlaceKind = new ObservableCollection<PlaceKindView>();
            listPlaceKind.Add(new PlaceKindView() { IsCheck = false, NameKind = "Cafe",Description="Tìm quán cafe ngon..." });
            listPlaceKind.Add(new PlaceKindView() { IsCheck = false, NameKind = "Hotel", Description = "Nơi dừng chân nghĩ ngơi..." });
            listPlaceKind.Add(new PlaceKindView() { IsCheck = false, NameKind = "Restaurance", Description = "Những món ăn ngon" });
            listPlaceKind.Add(new PlaceKindView() { IsCheck = false, NameKind = "Bar", Description = "Nơi giải trí tuyệt vời..." });
        }
        public static PlaceKindViewModel intanceCurrent = new PlaceKindViewModel();


    }
}
