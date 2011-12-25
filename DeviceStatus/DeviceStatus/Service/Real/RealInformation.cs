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
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Devices;
using System.Collections.ObjectModel;
using Microsoft.Devices.Sensors;

namespace DeviceStatus
{
    /// <summary>
    /// Represents information retrieved from an actual device.
    /// </summary>
    public class RealInformation : IInformationProvider
    {
        private DeviceInformation deviceInformation;
        private NetworkInformation networkInformation;
        private CapabilityInformation capabilitiesInformation;
                       
        #region Constructor


        /// <summary>
        /// Initializes a new instance with the appropriate data sources.
        /// </summary>
        public RealInformation()
        {
            deviceInformation = new RealDeviceInformation();
            networkInformation = new RealNetworkInformation();
            capabilitiesInformation = new RealCapabilityInformation();
        }


        #endregion        

        #region IInformationProvider Members

        
        public DeviceInformation Device
        {
            get { return deviceInformation; }
        }

        public NetworkInformation Network
        {
            get { return networkInformation; }
        }

        public CapabilityInformation Capabilities
        {
            get { return capabilitiesInformation; }
        }


        #endregion
    }
}
