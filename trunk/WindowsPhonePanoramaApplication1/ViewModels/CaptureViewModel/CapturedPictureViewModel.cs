
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
using System.Runtime.Serialization;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Phone;
using AccessingWP7Devices.Assets.Serialization;

namespace WindowsPhonePanoramaApplication1.ViewModels.CaptureViewModel
{
    [DataContract]
    public class CapturedPictureViewModel : Picture
    {
        [DataMember]
        public byte[] ImageBytes
        {
            get;
            set;
        }

        [DataMember]
        public string FileName
        {
            get;
            set;
        }

        public CapturedPictureViewModel()
        {
        }

        public CapturedPictureViewModel(string capturedFileName, Stream capturedImageStream)
        {
            ImageBytes = ReadImageBytes(capturedImageStream);
            DateTaken = DateTime.Now.ToLongDateString();
            FileName = System.IO.Path.GetFileName(capturedFileName);
        }

        public override void Serialize(BinaryWriter writer)
        {
            base.Serialize(writer);
            writer.Write(ImageBytes.Length);
            writer.Write(ImageBytes);
            writer.WriteString(FileName);
        }

        public override void Deserialize(BinaryReader reader)
        {
            base.Deserialize(reader);
            int bytesCount = reader.ReadInt32();
            ImageBytes = reader.ReadBytes(bytesCount);
            FileName = reader.ReadString();
        }

        protected override BitmapSource CreateBitmapSource()
        {
            BitmapSource source = null;
            if (ImageBytes != null)
            {
                using (var stream = new MemoryStream(ImageBytes))
                {
                    source = PictureDecoder.DecodeJpeg(stream);
                }
            }

            return source;
        }

        private byte[] ReadImageBytes(Stream imageStream)
        {
            byte[] imageBytes = new byte[imageStream.Length];
            imageStream.Read(imageBytes, 0, imageBytes.Length);
            return imageBytes;
        }
    }
}
