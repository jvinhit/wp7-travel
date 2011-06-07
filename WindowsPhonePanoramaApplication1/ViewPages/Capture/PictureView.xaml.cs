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
using WindowsPhonePanoramaApplication1.ViewModels.CaptureViewModel;
using System.Windows.Media.Imaging;
using Microsoft.Xna.Framework.Input.Touch;

namespace WindowsPhonePanoramaApplication1.ViewPages.Capture
{
    public partial class PictureView : PhoneApplicationPage
    {
  
    
        public PictureView()
        {
            InitializeComponent();
            this.DataContext = PictureViewViewModel.instance.pictures;
            PictureViewViewModel.instance.UpdateImage();
            TouchPanel.EnabledGestures = GestureType.Flick;
            
   
            
        }

        private void ContentPanel_MouseMove(object sender, MouseEventArgs e)
        {
           
        }
        private void Image_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            // The IsGestureAvailable property will tell us if a gesture
            // has been recognised. It's possible there's more than one
            while (TouchPanel.IsGestureAvailable)
            {
                // Read and respond to the current gesture
                GestureSample gesture = TouchPanel.ReadGesture();

                if (gesture.GestureType == GestureType.Flick)
                {
                    // determine direction
                    var modifier = gesture.Delta.Y > 0 ? -1 : 1;
                    if (modifier == 1)
                    {
                        PictureViewViewModel.instance.NextImage();
                    }
                    else
                    {
                        PictureViewViewModel.instance.PreImage();
                    }

                   
                }
            }
        }
    }
}