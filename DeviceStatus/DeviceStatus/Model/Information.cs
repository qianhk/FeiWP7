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
using System.ComponentModel;

namespace DeviceStatus
{
    /// <summary>
    /// A class which represents information contained in instance proeprties.
    /// </summary>
    public abstract class Information : INotifyPropertyChanged
    {
        #region Constructors


        /// <summary>
        /// Creates a new instance of the object and refreshes the data it contains.
        /// </summary>
        public Information()
        {
            RefreshData();
        }


        #endregion

        #region Public methods


        /// <summary>
        /// Refreshes the data contained in the object.
        /// </summary>
        public abstract void RefreshData();

        /// <summary>
        /// Notifies of property changes performed.
        /// </summary>
        /// <param name="propertyName">The name of the property which has been changed.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #endregion

        #region INotifyPropertyChanged Members


        /// <summary>
        /// Notifies of any property changes which occurred in the object.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        #endregion
    }
}
