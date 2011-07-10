using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WindowsPhonePanoramaApplication1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items1 = new ObservableCollection<ItemViewModel1>();
            this.Items2 = new ObservableCollection<ItemViewModel2>();
            
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel1> Items1 { get; private set; }
        public ObservableCollection<ItemViewModel2> Items2 { get; private set; }

        // weather funtion
        //public ObservableCollection<WeatherViewMode> ItemsWeather { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Items1.Add(new ItemViewModel1() { LineOne = "Vịnh Hạ Long", LineTwo = "Vịnh Hạ Long nằm ....", LineThree = "Vịnh Hạ Long nằm ở vùng Đông Bắc Việt Nam, là một phần phía tây Vịnh Bắc Bộ, bao gồm vùng biển của thành phố Hạ Long, thị xã Cẩm Phả và một phần của huyện đảo Vân Đồn. Phía tây nam giáp đảo Cát Bà, phía tây giáp đất liền với đường bờ biển dài 120 km, Vịnh có tổng diện tích 1553 km2 gồm 1969 hòn đảo lớn nhỏ, trong đó 989 đảo có tên và 980 đảo chưa có tên. Vùng Di sản được Thế giới công nhận có diện tích 434 km2 bao gồm 775 đảo, như một hình tam giác với ba đỉnh là đảo Đầu Gỗ (phía tây), hồ Ba Hầm (phía nam) và đảo Cống Tây (phía đông). " });
            this.Items1.Add(new ItemViewModel1() { LineOne = "Vườn Quốc gia Phong Nha", LineTwo = "Vườn Quốc gia Phong Nha ....", LineThree = "Vịnh Hạ Long nằm ở vùng Đông Bắc Việt Nam, là một phần phía tây Vịnh Bắc Bộ, bao gồm vùng biển của thành phố Hạ Long, thị xã Cẩm Phả và một phần của huyện đảo Vân Đồn. Phía tây nam giáp đảo Cát Bà, phía tây giáp đất liền với đường bờ biển dài 120 km, Vịnh có tổng diện tích 1553 km2 gồm 1969 hòn đảo lớn nhỏ, trong đó 989 đảo có tên và 980 đảo chưa có tên. Vùng Di sản được Thế giới công nhận có diện tích 434 km2 bao gồm 775 đảo, như một hình tam giác với ba đỉnh là đảo Đầu Gỗ (phía tây), hồ Ba Hầm (phía nam) và đảo Cống Tây (phía đông). " });
            this.Items1.Add(new ItemViewModel1() { LineOne = "Khu đền tháp Mỹ Sơn ", LineTwo = "Mỹ Sơn thuộc địa phận xã Duy....", LineThree = "Vịnh Hạ Long nằm ở vùng Đông Bắc Việt Nam, là một phần phía tây Vịnh Bắc Bộ, bao gồm vùng biển của thành phố Hạ Long, thị xã Cẩm Phả và một phần của huyện đảo Vân Đồn. Phía tây nam giáp đảo Cát Bà, phía tây giáp đất liền với đường bờ biển dài 120 km, Vịnh có tổng diện tích 1553 km2 gồm 1969 hòn đảo lớn nhỏ, trong đó 989 đảo có tên và 980 đảo chưa có tên. Vùng Di sản được Thế giới công nhận có diện tích 434 km2 bao gồm 775 đảo, như một hình tam giác với ba đỉnh là đảo Đầu Gỗ (phía tây), hồ Ba Hầm (phía nam) và đảo Cống Tây (phía đông). " });
            this.Items1.Add(new ItemViewModel1() { LineOne = "Khu di tích trung tâm Hoàng thành ", LineTwo = "Khu di tích trung tâm Hoàn....", LineThree = "Vịnh Hạ Long nằm ở vùng Đông Bắc Việt Nam, là một phần phía tây Vịnh Bắc Bộ, bao gồm vùng biển của thành phố Hạ Long, thị xã Cẩm Phả và một phần của huyện đảo Vân Đồn. Phía tây nam giáp đảo Cát Bà, phía tây giáp đất liền với đường bờ biển dài 120 km, Vịnh có tổng diện tích 1553 km2 gồm 1969 hòn đảo lớn nhỏ, trong đó 989 đảo có tên và 980 đảo chưa có tên. Vùng Di sản được Thế giới công nhận có diện tích 434 km2 bao gồm 775 đảo, như một hình tam giác với ba đỉnh là đảo Đầu Gỗ (phía tây), hồ Ba Hầm (phía nam) và đảo Cống Tây (phía đông). " });
            this.Items1.Add(new ItemViewModel1() { LineOne = "Đô thị cổ Hội An", LineTwo = "Hội An là một thị xã cổ ....", LineThree = "Vịnh Hạ Long nằm ở vùng Đông Bắc Việt Nam, là một phần phía tây Vịnh Bắc Bộ, bao gồm vùng biển của thành phố Hạ Long, thị xã Cẩm Phả và một phần của huyện đảo Vân Đồn. Phía tây nam giáp đảo Cát Bà, phía tây giáp đất liền với đường bờ biển dài 120 km, Vịnh có tổng diện tích 1553 km2 gồm 1969 hòn đảo lớn nhỏ, trong đó 989 đảo có tên và 980 đảo chưa có tên. Vùng Di sản được Thế giới công nhận có diện tích 434 km2 bao gồm 775 đảo, như một hình tam giác với ba đỉnh là đảo Đầu Gỗ (phía tây), hồ Ba Hầm (phía nam) và đảo Cống Tây (phía đông). " });
         
            // function app


            this.Items2.Add(new ItemViewModel2() { LineOne = (String)Application.Current.Resources["MainPages_3"], LineTwo = (String)Application.Current.Resources["MainPages_3_1"], PathIcon = "/WindowsPhonePanoramaApplication1;component/Images/IconFunctions/icon_news.png", IdFuntion = EnumsFunction.News.ToString(), TagLink = "/Views/News/NewsPage.xaml" });
            this.Items2.Add(new ItemViewModel2() { LineOne = (String)Application.Current.Resources["MainPages_4"], LineTwo = (String)Application.Current.Resources["MainPages_4_1"], PathIcon = "/WindowsPhonePanoramaApplication1;component/Images/IconFunctions/GoogleIcon.png", IdFuntion = EnumsFunction.GoogleMapFunc.ToString(), TagLink = "/Views/GoogleMaps/GoogleMaps.xaml" });
            this.Items2.Add(new ItemViewModel2() { LineOne = (String)Application.Current.Resources["MainPages_5"], LineTwo = (String)Application.Current.Resources["MainPages_5_1"], PathIcon = "/WindowsPhonePanoramaApplication1;component/Images/IconFunctions/WeatherIcon.png", IdFuntion = EnumsFunction.WeatherFunc.ToString(), TagLink = "/Views/WeatherViews/WeatherView.xaml" });
            this.Items2.Add(new ItemViewModel2() { LineOne = (String)Application.Current.Resources["MainPages_6"], LineTwo = (String)Application.Current.Resources["MainPages_6_1"], PathIcon = "/WindowsPhonePanoramaApplication1;component/Images/IconFunctions/CurrencyFunction.png", IdFuntion = EnumsFunction.CurrencyConvert.ToString(), TagLink = "/Views/Currency/Currency.xaml" });
            this.Items2.Add(new ItemViewModel2() { LineOne = (String)Application.Current.Resources["MainPages_7"], LineTwo = (String)Application.Current.Resources["MainPages_7_1"], PathIcon = "/WindowsPhonePanoramaApplication1;component/Images/IconFunctions/cameraFunction.png", IdFuntion = EnumsFunction.CurrencyConvert.ToString(), TagLink = "/Views/Capture/PictureList.xaml" });
            this.Items2.Add(new ItemViewModel2() { LineOne = (String)Application.Current.Resources["MainPages_8"], LineTwo = (String)Application.Current.Resources["MainPages_8_1"], PathIcon = "/WindowsPhonePanoramaApplication1;component/Images/IconFunctions/settings.png", IdFuntion = EnumsFunction.CurrencyConvert.ToString(), TagLink = "/Views/Setting/SettingPage.xaml" });
            
            this.IsDataLoaded = true;
        }

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