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
    public abstract class CapabilityInformation : Information
    {
        #region Properties and supporting fields


        private ObservableCollection<string> supportedResolutions;

        /// <summary>
        /// Gets the resolutions supported by the device's camera.
        /// </summary>
        public ObservableCollection<string> SupportedResolutions
        {
            get
            {
                return supportedResolutions;
            }
            set
            {
                if (value != supportedResolutions)
                {
                    supportedResolutions = value;
                    NotifyPropertyChanged("SupportedResolutions");
                }
            }
        }

        private bool isGyroSuppoted;

        /// <summary>
        /// Whether or not the device has a built in gyroscope.
        /// </summary>
        public bool IsGyroSupported
        {
            get
            {
                return isGyroSuppoted;
            }
            set
            {
                if (value != isGyroSuppoted)
                {
                    isGyroSuppoted = value;
                    NotifyPropertyChanged("IsGyroSupported");
                }
            }
        }

        private bool isAccelerometerSupported;

        /// <summary>
        /// Whether or not the device has a built in accelerometer.
        /// </summary>
        public bool IsAccelerometerSupported
        {
            get
            {
                return isAccelerometerSupported;
            }
            set
            {
                if (value != isAccelerometerSupported)
                {
                    isAccelerometerSupported = value;
                    NotifyPropertyChanged("IsConnected");
                }
            }
        }

        private bool isCompassSupported;

        /// <summary>
        /// Whether or not the device has a built in compass.
        /// </summary>
        public bool IsCompassSupported
        {
            get
            {
                return isCompassSupported;
            }
            set
            {
                if (value != isCompassSupported)
                {
                    isCompassSupported = value;
                    NotifyPropertyChanged("IsCompassSupported");
                }
            }
        }

        private bool isMotionSupported;

        /// <summary>
        /// Whether or not the device has a built in motion sensor.
        /// </summary>
        public bool IsMotionSupported
        {
            get
            {
                return isMotionSupported;
            }
            set
            {
                if (value != isMotionSupported)
                {
                    isMotionSupported = value;
                    NotifyPropertyChanged("IsMotionSupported");
                }
            }
        }


        #endregion
    }
}
