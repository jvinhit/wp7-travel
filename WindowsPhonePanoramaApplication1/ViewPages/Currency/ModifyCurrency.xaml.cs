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
using WindowsPhonePanoramaApplication1.ViewModels.CurrencyViewModel;
using Bewise.Phone;
using System.ComponentModel;

namespace WindowsPhonePanoramaApplication1.ViewPages.Currency
{
    
    public partial class ModifyCurrency : PhoneApplicationPage 
    {
        
        public ModifyCurrency()
        {
            InitializeComponent();
        }
        
 

        private void lstUsers_SelectedItemChanged(object sender, EventArgs e)
        {

            Adapter adapter = (Adapter)lstUsers.SelectedItem;
            IDictionary<string, string> queryString = this.NavigationContext.QueryString;
            string buffer = string.Empty;

            if (queryString.ContainsKey("isFromCurrency"))
            {
                buffer = queryString["isFromCurrency"];
            }

            if (buffer != string.Empty)
            {
                string temp = String.Format("{0}-{1}", adapter.Description.Trim(), adapter.Name.Trim());
                if (buffer.Trim() == "1")
                {
                    //ListCurrencyViewModel.instanceCurrency.ListCurrencyCountry[0].
                    ListCurrencyViewModel.instanceCurrency.UpdateCurrencyConvert(true, temp);
                }
                else
                {
                    //CurrencyConvertView.currentInstance.CurrencyTo = String.Format("{0}-{1}", ((TextBlock)sender).Text.Trim(), ((TextBlock)sender).Tag.ToString().Trim());
                    ListCurrencyViewModel.instanceCurrency.UpdateCurrencyConvert(false, temp);
                }

            }

            
            //this.NavigationService.Navigate(new Uri("/ViewPages/Currency/Currency.xaml", UriKind.Relative));
            //this.Resources = null;
            //if (this.NavigationService.CanGoBack)
            //{
            //    collection.Clear();
            //    lstUsers.ItemsSource = null;
               
         
               this.NavigationService.GoBack();
            //}

        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
           
            ItemObservableCollection<Adapter> collection = new ItemObservableCollection<Adapter>();

            if (collection.Count == 0)
            {
                foreach (ListCurrencyView temp in ListCurrencyViewModel.instanceCurrency.ListCurrencyCountry)
                {
                    collection.Add(new Adapter { Name = temp.Symbol, Description = temp.FullNameCurrency });
                }
            }

            lstUsers.ItemsSource = collection;
        }
    }


    public class Adapter : INotifyPropertyChanged
    {
        string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        string description;

        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public string Image
        {
            get
            {
                return "/Images/list.png";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}