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

namespace DeviceStatus
{
    /// <summary>
    /// Provides information about the device's actual capabilities.
    /// </summary>
    public class RealCapabilityInformation : CapabilityInformation
    {
        /// <summary>
        /// Examines the device to detect its capabilities.
        /// </summary>
        public override void RefreshData()
        {
            IsGyroSupported = Microsoft.Devices.Sensors.Gyroscope.IsSupported;
            IsAccelerometerSupported =
            Microsoft.Devices.Sensors.Accelerometer.IsSupported;
            IsCompassSupported = Microsoft.Devices.Sensors.Compass.IsSupported;
            IsMotionSupported = Microsoft.Devices.Sensors.Motion.IsSupported;

        }
    }
}
