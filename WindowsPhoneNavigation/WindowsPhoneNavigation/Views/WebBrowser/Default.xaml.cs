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

namespace WindowsPhoneNavigation.Views.WebBrowser
{
    public partial class Default : PhoneApplicationPage
    {
        private const string httpPrefix = "http://";

        public Default()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Default_Loaded);
        }

        private void Default_Loaded(object sender, RoutedEventArgs e)
        {
            if (NavigationContext.QueryString.Count > 0)
            {
                string urlToNavigate = NavigationContext.QueryString.Values.First();

                if (urlToNavigate.IndexOf(httpPrefix) == -1)
                    urlToNavigate = httpPrefix + urlToNavigate;

                Uri uri = new Uri(urlToNavigate, UriKind.Absolute);

                if (null != uri)
                    wb.Navigate(uri);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string urlToNavigate =
               txtURL.Text.IndexOf(httpPrefix) > -1 ?
               txtURL.Text : httpPrefix + txtURL.Text;
            Uri uri = new Uri(urlToNavigate, UriKind.Absolute);

            if (null != uri)
                wb.Navigate(uri);
        }
    }
}