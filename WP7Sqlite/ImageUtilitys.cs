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
using System.IO;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.Windows.Resources;


namespace WP7Shared
{
    public static class ImageUtilitys
    {
        public static BitmapImage GetBitmapImageFromArrayByte(byte[] inputData)
        {
            MemoryStream ms = new MemoryStream(inputData);
            ms.Seek(0, SeekOrigin.Begin);
            BitmapImage bitmapimage = new BitmapImage();
            bitmapimage.SetSource(ms);
            return bitmapimage;
        }
        public static BitmapSource GetBitmapSourceFromBitmapImage(BitmapImage bitmapImage)
        {
            return (BitmapSource)bitmapImage;
        }
        public static BitmapSource GetBitmapSourceFromArrayByte(byte[] inputData)
        {
            return (BitmapSource)ImageUtilitys.GetBitmapImageFromArrayByte(inputData);
        }



        public static void SaveImage(string nameFile, BitmapImage bitmap)
        { 
            // Create a filename for JPEG file in isolated storage.
            // String tempJPEG = "logo.jpg";
 
            // Create virtual store and file stream. Check for duplicate tempJPEG files.
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(nameFile))
                {
                    myIsolatedStorage.DeleteFile(nameFile);
                }

                IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(nameFile);

                //StreamResourceInfo sri = null;
                //Uri uri = new Uri(tempJPEG, UriKind.Relative);
                //sri = Application.GetResourceStream(uri);

                //BitmapImage bitmap = new BitmapImage();
                //bitmap.SetSource(sri.Stream);
                WriteableBitmap wb = new WriteableBitmap(bitmap);

                // Encode WriteableBitmap object to a JPEG stream.
                Extensions.SaveJpeg(wb, fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);

                //wb.SaveJpeg(fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                fileStream.Close();
            }
        }

        public static void DeleteFile(string nameFile)
        {
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(nameFile))
                {
                    myIsolatedStorage.DeleteFile(nameFile);
                }

              
            }
        }
        public static BitmapImage ReadBitmapImage(String fileName)
        {
            BitmapImage bi = new BitmapImage();

            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(fileName, FileMode.Open, FileAccess.Read))
                {
                    bi.SetSource(fileStream);
           
                }
            }

            return bi;
            
        }

      


        
     


    }
}
