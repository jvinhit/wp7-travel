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
using System.Linq;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using Microsoft.Phone.Controls.Maps;
using TravelObject;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Device.Location;
using System.ComponentModel;
using System.IO;


namespace WindowsPhonePanoramaApplication1.Models.GoogleViewModel
{
    public class GoogleViewModel : INotifyPropertyChanged
    {

        public static GoogleViewModel InstanceCurrent = new GoogleViewModel();
      

        #region Property
   
        public PlaceKindViewModel placeKind=PlaceKindViewModel.intanceCurrent;

  
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        /// <value>Default map zoom level.</value>
        private double DefaultZoomLevel = MarkOnMap.ZoomLevelCurrent;

        /// <value>Maximum map zoom level allowed.</value>
        private const double MaxZoomLevel = 21.0;

        /// <value>Minimum map zoom level allowed.</value>
        private const double MinZoomLevel = 1.0;
        private static GeoCoordinate DefaultLocation = MarkOnMap.Current;
        /// <value>Collection of pushpins available on map.</value>
        public ObservableCollection<PlaceObject> _pushpins = new ObservableCollection<PlaceObject>();
        

        /// <value>Map zoom level.</value>
        private double _zoom;

        /// <value>Map center coordinate.</value>
        private GeoCoordinate _center;

        /// <summary>
        /// Gets or sets the map zoom level.
        /// </summary>
        public double Zoom
        {
            get { return _zoom; }
            set
            {
                var coercedZoom = Math.Max(MinZoomLevel, Math.Min(MaxZoomLevel, value));
                if (_zoom != coercedZoom)
                {
                    _zoom = value;
                    NotifyPropertyChanged("Zoom");
                }
            }
        }

        /// <summary>
        /// Gets or sets the map center location coordinate.
        /// </summary>
        public GeoCoordinate Center
        {
            get { return _center; }
            set
            {
                if (_center != value)
                {
                    _center = value;
                    NotifyPropertyChanged("Center");
                }
            }
        }

        public ObservableCollection<PlaceObject> Pushpins
        {
            get {return _pushpins; }
        }


        #endregion

        #region Method
        private GoogleViewModel()
        {
            // sample data

            //get coffe 


            //ObservableCollection<PlaceObject> listCoffee = new ObservableCollection<PlaceObject>();
            //_pushpins.Clear();
            //listCoffee.Add(new CafePlace() { geoCoor = new GeoCoordinate(10.7669, 106.6918) });
            //listCoffee.Add(new CafePlace() { geoCoor = new GeoCoordinate(10.7627, 106.6893) });
            //listCoffee.Add(new CafePlace() { geoCoor = new GeoCoordinate(10.7669, 106.6876) });
            //foreach (var tempIndex in listCoffee.ToList<PlaceObject>())
            //{
            //    _pushpins.Add(tempIndex);
            //}
            
           
            ////get hotel
            

            //ObservableCollection<PlaceObject> listHotel = new ObservableCollection<PlaceObject>();
            //listHotel.Add(new HotelPlace() { geoCoor = new GeoCoordinate(10.7664, 106.6988) });
            //listHotel.Add(new HotelPlace() { geoCoor = new GeoCoordinate(10.7690, 106.6887) });
            //listHotel.Add(new HotelPlace() { geoCoor = new GeoCoordinate(10.7621, 106.6914) });
            //foreach (var tempIndex in listHotel.ToList<PlaceObject>())
            //{
            //    _pushpins.Add(tempIndex);
            //}
            
            


        }

        public void GotoCenterMap()
        {
            Center = MarkOnMap.Current;
            Zoom = MarkOnMap.ZoomLevelCurrent;

        }
        #endregion
    }
}
