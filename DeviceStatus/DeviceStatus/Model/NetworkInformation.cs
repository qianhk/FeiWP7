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
    public abstract class NetworkInformation : Information
    {
        #region Properties and supporting fields


        private bool isConnected;

        /// <summary>
        /// Whether or not the device is connected to the network.
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return isConnected;
            }
            set
            {
                if (value != isConnected)
                {
                    isConnected = value;
                    NotifyPropertyChanged("IsConnected");
                }
            }
        }

        string connectionType;

        /// <summary>
        /// The type of connection through which the phone is connected to the network.
        /// </summary>
        public string ConnectionType
        {
            get
            {
                return connectionType;
            }
            set
            {
                if (value != connectionType)
                {
                    connectionType = value;
                    NotifyPropertyChanged("ConnectionType");
                }
            }
        }

        private string mobileOperator;

        /// <summary>
        /// The mobile operator which the phone is connected to.
        /// </summary>
        public string MobileOperator
        {
            get
            {
                return mobileOperator;
            }
            set
            {
                if (value != mobileOperator)
                {
                    mobileOperator = value;
                    NotifyPropertyChanged("MobileOperator");
                }
            }
        }

        private bool isCellularDataEnabled;

        /// <summary>
        /// Whether or not data over a cellular connection is enabled.
        /// </summary>
        public bool IsCellularDataEnabled
        {
            get
            {
                return isCellularDataEnabled;
            }
            set
            {
                if (value != isCellularDataEnabled)
                {
                    isCellularDataEnabled = value;
                    NotifyPropertyChanged("IsCellularDataEnabled");
                }
            }
        }

        private bool isCellularDataRoamingEnabled;

        /// <summary>
        /// Whether or not data roaming over a cellular connection is enabled.
        /// </summary>
        public bool IsCellularDataRoamingEnabled
        {
            get
            {
                return isCellularDataRoamingEnabled;
            }
            set
            {
                if (value != isCellularDataRoamingEnabled)
                {
                    isCellularDataRoamingEnabled = value;
                    NotifyPropertyChanged("IsCellularDataRoamingEnabled");
                }
            }
        }

        private bool isWifiEnabled;

        /// <summary>
        /// Whether or not wireless networking is enabled.
        /// </summary>
        public bool IsWifiEnabled
        {
            get
            {
                return isWifiEnabled;
            }
            set
            {
                if (value != isWifiEnabled)
                {
                    isWifiEnabled = value;
                    NotifyPropertyChanged("IsWifiEnabled");
                }
            }
        }

        #endregion
    }
}
