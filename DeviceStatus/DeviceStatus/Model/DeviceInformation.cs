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
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DeviceStatus
{
    /// <summary>
    /// Represents device information presented by the application.
    /// </summary>
    public abstract class DeviceInformation : Information
    {
        #region Properties and supporting fields
        

        private string powerSource;

        /// <summary>
        /// Gets a string describing the device's power source.
        /// </summary>
        public string PowerSource
        {
            get
            {
                return powerSource;
            }
            set
            {
                if (value != powerSource)
                {                    
                    powerSource = value;
                    NotifyPropertyChanged("PowerSource");
                }
            }
        }

        private string firmwareVersion;

        /// <summary>
        /// Gets a string describing the device's firmware version.
        /// </summary>
        public string FirmwareVersion
        {
            get
            {
                return firmwareVersion;
            }
            set
            {
                if (value != firmwareVersion)
                {                    
                    firmwareVersion = value;
                    NotifyPropertyChanged("FirmwareVersion");
                }
            }
        }

        private string hardwareVersion;

        /// <summary>
        /// Gets a string describing the device's hardware version.
        /// </summary>
        public string HardwareVersion
        {
            get
            {
                return hardwareVersion;
            }
            set
            {
                if (value != hardwareVersion)
                {                    
                    hardwareVersion = value;
                    NotifyPropertyChanged("HardwareVersion");
                }
            }
        }

        private string manufacturer;

        /// <summary>
        /// Gets a string representing the device's manufacturer.
        /// </summary>
        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                if (value != manufacturer)
                {                    
                    manufacturer = value;
                    NotifyPropertyChanged("Manufacturer");
                }
            }
        }

        private string name;

        /// <summary>
        /// Gets a string containing the device's name.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {                    
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private string totalMemory;

        /// <summary>
        /// Gets a string containing the total amount of memory present on the device.
        /// </summary>
        public string TotalMemory
        {
            get
            {
                return totalMemory;
            }
            set
            {
                if (value != totalMemory)
                {
                    totalMemory = value;
                    NotifyPropertyChanged("TotalMemory");
                }
            }
        }

        private bool hasKeyboard;

        /// <summary>
        /// Whether or not the device has a physical keyboard.
        /// </summary>
        public bool HasKeyboard
        {
            get
            {
                return hasKeyboard;
            }
            set
            {
                if (value != hasKeyboard)
                {
                    hasKeyboard = value;
                    NotifyPropertyChanged("HasKeyboard");
                }
            }
        }


        #endregion       
    }
}
