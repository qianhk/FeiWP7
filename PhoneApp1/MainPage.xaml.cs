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
using Microsoft.Phone.Shell;

namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        Random rand = new Random();
        Brush originalBrush;
        PhoneApplicationService appService = PhoneApplicationService.Current;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            originalBrush = txtblk.Foreground;
            Touch.FrameReported += onTouchFrameReported;
        }

        private void onTouchFrameReported(object sender, TouchFrameEventArgs e)
        {
            TouchPoint primaryTouchPoint = e.GetPrimaryTouchPoint(null);
            if (primaryTouchPoint != null && primaryTouchPoint.Action == TouchAction.Down)
            {
                if (primaryTouchPoint.TouchDevice.DirectlyOver == txtblk)
                {
                    txtblk.Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)rand.Next(256), (byte)rand.Next(256), (byte)rand.Next(256)));
                }
                else if (primaryTouchPoint.TouchDevice.DirectlyOver != KaiSon)
                {
                    txtblk.Foreground = originalBrush;
                }
            }
        }

        private void OnContentPanelSizeChanged(object sender, SizeChangedEventArgs e)
        {
            //txtblk.Text = String.Format("ContentPanel size: {0}\n" +
            //    "TitlePanel size: {1}\nLayoutRoot Size: {2}\nMainPage size: {3}\nFrame size: {4}", e.NewSize,
            //    new Size(TitlePanel.ActualWidth, TitlePanel.ActualHeight),
            //    new Size(LayoutRoot.ActualWidth, LayoutRoot.ActualHeight),
            //    new Size(this.ActualWidth, this.ActualHeight), Application.Current.RootVisual.RenderSize);
        }

        void onImageManipulationStarted(object sender, ManipulationStartedEventArgs args)
        {
            NavigationService.Navigate(new Uri("/SecondPage.xaml", UriKind.Relative));
            args.Complete();
            args.Handled = true;
        }

        protected override void OnOrientationChanged(OrientationChangedEventArgs e)
        {
            txtblk.Text = e.Orientation.ToString();
            base.OnOrientationChanged(e);
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (txtblk.Foreground is SolidColorBrush)
            {
                appService.State["color"] = (txtblk.Foreground as SolidColorBrush).Color;
            }
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            //if (appService.State.ContainsKey("color"))
            //{
            //    Color c = (Color)appService.State["color"];
            //    txtblk.Foreground = new SolidColorBrush(c);
            //}
            base.OnNavigatedTo(e);
        }
    }
}