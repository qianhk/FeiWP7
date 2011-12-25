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

namespace DeviceStatus
{
    /// <summary>
    /// Provides device information for design time.
    /// </summary>
    public class FakeDeviceInformation : DeviceInformation
    {
        /// <summary>
        /// Returns arbitrary made up data.
        /// </summary>
        public override void RefreshData()
        {
            PowerSource = "Steam";
            FirmwareVersion = "3.1.4.7";
            HardwareVersion = "3.1.4.7";
            Manufacturer = "Meat-tech Co.";
            Name = "Beef Phone Z34";
            TotalMemory = "5PB";
            HasKeyboard = true;
        }
    }
}
