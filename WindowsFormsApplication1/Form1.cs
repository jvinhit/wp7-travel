using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.ServiceReference1;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private static TravelService. ClientSerice { get; set; }
        private static string AccessToken { get; set; }
        private static string ClientTag { get; set; }



        private static T PrepareRequest<T>(T request) where T : RequestBase
        {
            request.RequestId = Guid.NewGuid().ToString();  // Generates unique request id
            request.ClientTag = ClientTag;
            request.AccessToken = AccessToken;

            return request;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceReference1.MainServiceClient client = new ServiceReference1.MainServiceClient();
            var request = PrepareRequest(new MapImageRequest());
            request.mapImageDTO = new MapImageDTO();
            //System.Windows.Size size = new System.Windows.Size((Double)557, (Double)421);

            ////size.Height = (Double)557;
            ////size.Width = (Double)421;

            request.mapImageDTO.Latitude = 40.714728;
            request.mapImageDTO.Longitude = -73.998672;
            request.mapImageDTO.Width = 749;
            request.mapImageDTO.Height = 279;
            request.mapImageDTO.Zoom = 13;
            request.mapImageDTO.GetMaker = "markers=color:red|label:0|10.771550,106.698330";
            MemoryStream memoryStream ;
            var response = client.GetMapGoogle(request);
            memoryStream =  new MemoryStream((byte[])response.mapImageDTO.BitmapMapsStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            Bitmap t = new Bitmap(memoryStream);
            this.pictureBox1.Image = t;            
        }
    }
}
