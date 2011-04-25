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
using System.Collections.ObjectModel;
using WindowsPhonePanoramaApplication1.ViewModels.CurrencyViewModel;

namespace WindowsPhonePanoramaApplication1.ViewPages.Currency
{
    public partial class CurrencyModify : PhoneApplicationPage
    {
        

        public CurrencyModify()
        {
            InitializeComponent();
            
            //this.arrayCurrency = new ObservableCollection<ListCurrencyView>();
            this.DataContext = ListCurrencyViewModel.instanceCurrency;
            //List<string> listConstToListSort = new List<string>();
            //listConstToListSort = listConst.ToList<string>();
            //listConstToListSort.Sort();
            //foreach (string temp in listConstToListSort)
            //{
            //    this.arrayCurrency.Add(new ListCurrencyView() { FullNameCurrency = temp.Split('-')[1], Symbol = temp.Split('-')[0] });
            //}
       
           
        }

        private void listContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IDictionary<string, string> queryString = this.NavigationContext.QueryString;
            string buffer = string.Empty;

            if (queryString.ContainsKey("isFromCurrency")) 
            {
                buffer = queryString["isFromCurrency"];
            }
            if (buffer != string.Empty)
            {
                string temp = String.Format("{0}-{1}", ((TextBlock)sender).Text.Trim(), ((TextBlock)sender).Tag.ToString().Trim());
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

            if (this.NavigationService.CanGoBack) 
                    this.NavigationService.GoBack();
            
        }
    }
}