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
using  System.Linq;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using Microsoft.Phone.Controls.Maps;

namespace WindowsPhonePanoramaApplication1.ViewModels.GoogleViewModel
{
    public class GoogleViewModel
    {
        static string fileName = "Google.map";
        public static void LoadFromdDatabase(ref Microsoft.Phone.Controls.Maps.Map googlemap)
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                //Check if file exits
                if (isf.FileExists(fileName))
                {
                    //isf.OpenFile(fileName, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite);

                    using (IsolatedStorageFileStream fs = isf.OpenFile(fileName, System.IO.FileMode.Open))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(Microsoft.Phone.Controls.Maps.Map));
                        googlemap = (Microsoft.Phone.Controls.Maps.Map)ser.Deserialize(fs);
                    }

                }
                else
                {
                    isf.CreateFile(fileName);
                    googlemap.SetView(MarkOnMap.Current, MarkOnMap.ZoomLevelCurrent);
                }
            }
        }
        public static void SaveIntoDatabase(Microsoft.Phone.Controls.Maps.Map googlemap)
        {
            //MyDatabase.MainDatabase.mainDB.Table<GoogleMapView>()[0].googlemap = googlemap;
            //MyDatabase.MainDatabase.mainDB.Table<GoogleMapView>()[0].DateCreate = DateTime.Today;


            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                //Check if file exits
                if (isf.FileExists("Google.map"))
                {
                    using (IsolatedStorageFileStream fs = isf.OpenFile("Google.map", System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite))
                    {
                        //Read the file contents and try to deserialize it back to data object

                        XmlSerializer ser = new XmlSerializer(typeof(Map));
                        ser.Serialize(fs, googlemap);
                    }
                }
            }


        }
    }
}
