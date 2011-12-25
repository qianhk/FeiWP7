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
    /// Provides device information for the actual device.
    /// </summary>
    public class RealDeviceInformation : DeviceInformation
    {
        /// <summary>
        /// Gathers information from the device.
        /// </summary>
        public override void RefreshData()
        {
            PowerSource = Microsoft.Phone.Info.DeviceStatus.PowerSource.ToString();
            FirmwareVersion =
            Microsoft.Phone.Info.DeviceStatus.DeviceFirmwareVersion;
            HardwareVersion =
            Microsoft.Phone.Info.DeviceStatus.DeviceHardwareVersion;
            Manufacturer =
            Microsoft.Phone.Info.DeviceStatus.DeviceManufacturer;
            Name = Microsoft.Phone.Info.DeviceStatus.DeviceName;
            TotalMemory =
            (Microsoft.Phone.Info.DeviceStatus.DeviceTotalMemory /
            1048576).ToString() + "MB";
            HasKeyboard = Microsoft.Phone.Info.DeviceStatus.IsKeyboardPresent;

        }
    }
}
