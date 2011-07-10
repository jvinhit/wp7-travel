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
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.IO;
using System.Windows.Markup;

namespace WindowsPhonePanoramaApplication1
{
    public class StaticResourceDictionary : ResourceDictionary
    {
        string _kind;
        public string Kind
        {
            get { return _kind; }
            set
            {
                if (_kind != value)
                {
                    _kind = value;

                    try
                    {
                        switch (_kind.ToLower())
                        {
                            case "theme":
                                {
                                    string theme;

                                    if (IsolatedStorageSettings.ApplicationSettings.TryGetValue<string>("Theme", out theme) == false)
                                    {
                                        IsolatedStorageSettings.ApplicationSettings["Theme"] = "DarkBlue";
                                        theme = "DarkBlue";
                                    }
                                
                                    ResourceDictionary res = LoadXaml<ResourceDictionary>(new Uri(string.Format("WindowsPhonePanoramaApplication1;component/Themes/{0}/ThemeResources.xaml",
                                        theme), UriKind.RelativeOrAbsolute));

                                    MergedDictionaries.Add(res);
                                }
                                break;
                            case "languagepack":
                                {
                                    string LanguageName;

                                    if (IsolatedStorageSettings.ApplicationSettings.TryGetValue<string>("Languages", out LanguageName) == false)
                                    {
                                        IsolatedStorageSettings.ApplicationSettings["Languages"] = "EnglishPac";
                                        LanguageName = "EnglishPac";
                                    }
                                  

                                    ResourceDictionary res = LoadXaml<ResourceDictionary>(new Uri(string.Format("WindowsPhonePanoramaApplication1;component/Languages/{0}.xaml",
                                        LanguageName), UriKind.RelativeOrAbsolute));

                                    MergedDictionaries.Add(res);
                                }
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }

        T LoadXaml<T>(Uri uri)
        {
            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info != null)
            {
                using (StreamReader reader = new StreamReader(info.Stream))
                {
                    return (T)XamlReader.Load(reader.ReadToEnd());
                }
            }

            return default(T);
        }
    }
}
