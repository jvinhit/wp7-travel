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
using System.ComponentModel;

namespace WindowsPhonePanoramaApplication1.View.GoogleView
{
    public class PlaceKindView : INotifyPropertyChanged
    {
        private bool isCheck;

        public bool IsCheck
        {
            get { return isCheck; }
            set
            {
                if (value != isCheck)
                {
                    isCheck = value;
                    NotifyPropertyChanged("IsCheck");
                }
            }
        }
        private string nameKind;

        public string NameKind
        {
            get { return nameKind; }
            set
            {
                if (value != nameKind)
                {
                    nameKind = value;
                    NotifyPropertyChanged("NameKind");
                }
            }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                if (value != description)
                {
                    description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        public string IDPlaceKind;





        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
