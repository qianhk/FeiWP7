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
using System.Text;

namespace DeviceStatus
{
    /// <summary>
    /// Supplies information about the phone device.
    /// </summary>
    public interface IInformationProvider
    {
        /// <summary>
        /// Information about the device itself.
        /// </summary>
        DeviceInformation Device { get; }

        /// <summary>
        /// Information about the device's network capabilities.
        /// </summary>
        NetworkInformation Network { get; }

        /// <summary>
        /// Information about various features which the device supports.
        /// </summary>
        CapabilityInformation Capabilities { get; }
    }
}
