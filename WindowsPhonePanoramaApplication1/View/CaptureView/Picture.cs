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
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Device.Location;
using AccessingWP7Devices.Assets.Serialization;
using System.IO;


namespace WindowsPhonePanoramaApplication1.ViewModels.CaptureViewModel
{
    //public interface ISerializable
    //{
    //    void Serialize(BinaryWriter writer);
    //    void Deserialize(BinaryReader reader);
    //}


    [DataContract]
    public abstract class Picture : NotifyingObject, ISerializable
    {
        [DataMember]
        [TypeConverter(typeof(PositionTypeConverter))]
        public GeoCoordinate Position
        {
            get { return GetValue(() => Position); }
            set { SetValue(() => Position, value); }
        }

        [DataMember]
        public string Address
        {
            get { return GetValue(() => Address); }
            set { SetValue(() => Address, value); }
        }

        [DataMember]
        public string Note
        {
            get { return GetValue(() => Note); }
            set { SetValue(() => Note, value); }
        }

        [DataMember]
        public string DateTaken
        {
            get { return GetValue(() => DateTaken); }
            set { SetValue(() => DateTaken, value); }
        }

        [IgnoreDataMember]
        public BitmapSource Source
        {
            get
            {
                return CreateBitmapSource();
            }
        }

        protected abstract BitmapSource CreateBitmapSource();

        public virtual void Serialize(BinaryWriter writer)
        {
            var position = Position ?? GeoCoordinate.Unknown;
            writer.Write(position.Latitude);
            writer.Write(position.Longitude);
            writer.WriteString(Address);
            writer.WriteString(Note);
            writer.WriteString(DateTaken);
        }

        public virtual void Deserialize(BinaryReader reader)
        {
            double latitude = reader.ReadDouble();
            double longitude = reader.ReadDouble();
            Position = new GeoCoordinate(latitude, longitude);
            Address = reader.ReadString();
            Note = reader.ReadString();
            DateTaken = reader.ReadString();
        }

 
    }
}
