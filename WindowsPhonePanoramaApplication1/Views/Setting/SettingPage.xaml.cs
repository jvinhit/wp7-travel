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
using WindowsPhonePanoramaApplication1.Models.Setting;
using System.IO.IsolatedStorage;

namespace WindowsPhonePanoramaApplication1.Views.Setting
{
    public partial class SettingPage : PhoneApplicationPage
    {
        public SettingPage()
        {
            InitializeComponent();
            //this.DataContext = SettingViewModel.instance;
            this.LanguagesPicker.ItemsSource = SettingViewModel.instance.Languages;
            this.ThemePicker.ItemsSource = SettingViewModel.instance.Themes;
            this.AfterDayDelete.ItemsSource = SettingViewModel.instance.Days;

            String language;
            String Theme;
            String day;

            if (IsolatedStorageSettings.ApplicationSettings.TryGetValue<string>("Languages", out language) == true)
            {
                for (int i = 0; i < this.LanguagesPicker.Items.Count; i++)
                {
                    string t = this.LanguagesPicker.Items[i] as string;
                    if (t == language)
                        this.LanguagesPicker.SelectedIndex = i;

                }
            }
            if (IsolatedStorageSettings.ApplicationSettings.TryGetValue<string>("Theme", out Theme) == true)
            {
                for (int i = 0; i < this.ThemePicker.Items.Count; i++)
                {
                    string t = this.ThemePicker.Items[i] as string;
                    if (t == Theme)
                        this.ThemePicker.SelectedIndex = i;

                }
            }


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String language = LanguagesPicker.SelectedItem as string;
            String Theme = ThemePicker.SelectedItem as string;
            String day = AfterDayDelete.SelectedItem as string;

            if (language == "English")
            {
                IsolatedStorageSettings.ApplicationSettings["Languages"] = "EnglishPac";
            }
            else
                IsolatedStorageSettings.ApplicationSettings["Languages"] = "VietnamPac";


            if (Theme == "DarkBlue")
            {
                IsolatedStorageSettings.ApplicationSettings["Theme"] = "DarkBlue";
            }
            else
                IsolatedStorageSettings.ApplicationSettings["Theme"] = "DarkBrown";


                
            
            //IsolatedStorageSettings.ApplicationSettings["Languages"] = language.Trim();
           


            this.NavigationService.GoBack();
        }
    }
}