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

using System.IO;
using www.tannguyen.com.types;


namespace WindowsPhoneApplication1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
        //private static TravelService. ClientSerice { get; set; }
        private static string AccessToken { get; set; }
        private static string ClientTag { get; set; }
        private MainServiceClient ClientService;

       
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Create proxy object.
            ClientService = new MainServiceClient();
  
            // Gets client tag from app.config configuration file
            ClientTag = "ClientTag";
            // Retrieve AccessToken as first step
            var request = PrepareRequest(new MapImageRequest());
            request.mapImageDTO = new MapImageDTO();
            //System.Windows.Size size = new System.Windows.Size();
       
            //size.Height = 557;
            //size.Width = 421.0;

            request.mapImageDTO.Latitude=40.714728;
            request.mapImageDTO.Longitude=-73.998672;
            request.mapImageDTO.Width = 1300;
            request.mapImageDTO.Height = 2790;
            request.mapImageDTO.Zoom=12;
            request.mapImageDTO.GetMaker="markers=color:red|label:0|10.771550,106.698330";

            ClientService.GetMapGoogleCompleted += new EventHandler<GetMapGoogleCompletedEventArgs>(ClientService_GetMapGoogleCompleted);

            ClientService.GetMapGoogleAsync(request);
            
           

            // Store access token for all subsequent service calls.
            //AccessToken = response.AccessToken;
        }

        void ClientService_GetMapGoogleCompleted(object sender, GetMapGoogleCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Result == null)
            {
                return;
            }


            MapImageResponse response = e.Result;
            MemoryStream memoryStream;
       
            memoryStream = new MemoryStream((byte[])response.mapImageDTO.BitmapMapsStream);
            memoryStream.Seek(0, SeekOrigin.Begin);


            System.Windows.Media.Imaging.BitmapImage bImg = new System.Windows.Media.Imaging.BitmapImage();


            //bImg.BeginInit();

            //bImg.StreamSource = new MemoryStream(ms.ToArray());

            //bImg.EndInit();
            bImg.SetSource(memoryStream);
            this.image1.Source = bImg;
        }

        private static T PrepareRequest<T>(T request) where T : RequestBase
        {
            request.RequestId = Guid.NewGuid().ToString();  // Generates unique request id
            request.ClientTag = ClientTag;
            request.AccessToken = AccessToken;

            return request;
        }

    }
}