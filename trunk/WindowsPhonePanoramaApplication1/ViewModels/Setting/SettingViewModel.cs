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
using System.Collections.Generic;
using WindowsPhonePanoramaApplication1.View.Setting;


namespace WindowsPhonePanoramaApplication1.Models.Setting
{
    
    public class SettingViewModel : ViewModelBase
    {
        public List<String> Themes=new List<String>(){"DarkBlue","DarkBrown"};
        public List<String> Days=new List<String>(){"None","10 day","20 day","30 day, 60 day"};
        public List<String> Languages=new List<String>(){"English","VietNamese"};
        public SettingView settingViewCurrent;

        private SettingViewModel()
        {
            settingViewCurrent = new SettingView() { languages = Languages[0], numberDayForDelete = 0, themes = Themes[0] };

        }
        public static SettingViewModel instance = new SettingViewModel();


    }
}
