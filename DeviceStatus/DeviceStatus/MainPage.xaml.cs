// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

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
using Microsoft.Devices;
using System.Collections.ObjectModel;
using System.Windows.Navigation;


namespace DeviceStatus
{
    /// <summary>
    /// The main page of the application, presenting the user with information about the device.
    /// </summary>
    public partial class MainPage : PhoneApplicationPage
    {
        private VideoBrush videoBrush;

        /// <summary>
        /// Gets or sets the object use to interact with the device's camera.
        /// </summary>
        public PhotoCamera Camera { get; set; }

        /// <summary>
        /// Creates a new instance of the page.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        private void PanoStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PanoStatus.SelectedItem == null)
            {
                return;
            }

            if ((PanoStatus.SelectedItem as PanoramaItem).Header.ToString() == "capabilities")
            {
                Camera = new PhotoCamera();

                Camera.Initialized += camera_Initialized;

                videoBrush = new VideoBrush();
                videoBrush.Stretch = Stretch.Uniform;
                videoBrush.SetSource(Camera);

                cameraPreview.Fill = videoBrush;
            }
            else
            {
                UninitializeCamera();
            }

        }   
     
        protected override void OnNavigatedTo(NavigationEventArgs e)
{
//Theapplicationwasrestored
if(e.IsNavigationInitiator==false)
{
//Simulateapanoramachange,incaseweareviewingthe
        // capabilitiesitem
PanoStatus_SelectionChanged(this,null);
}

base.OnNavigatedTo(e);
}

protected override void OnNavigatedFrom(NavigationEventArgs e)
{
//Theapplicationwassenttothebackground
if(e.IsNavigationInitiator==false)
{
UninitializeCamera();
}

base.OnNavigatedFrom(e);
}

private void UninitializeCamera()
{
cameraPreview.Fill=null;

if(Camera!=null)
{
Camera.Dispose();
Camera=null;
}
}

private void camera_Initialized(object sender, CameraOperationCompletedEventArgs e)
{
Dispatcher.BeginInvoke(()=>
{
CapabilityInformation info=
(App.Current.Resources["DeviceInformationViewModel"]as
DeviceInformationViewModel).InformationProvider.Capabilities;

ObservableCollection<string>resolutions=
new ObservableCollection<string>();
foreach(Size resolution in Camera.AvailableResolutions)
{
resolutions.Add(String.Format("{0}x{1}",resolution.Width,
resolution.Height));
}

info.SupportedResolutions=resolutions;
});
}

    }
}