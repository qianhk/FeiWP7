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

namespace WindowsPhoneNavigation.Views.Music
{
    public partial class Default : PhoneApplicationPage
    {
        public Default()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Default_Loaded);

            this.BackKeyPress += (s, e) =>
            {
                if (media.CurrentState == MediaElementState.Playing)
                    media.Stop();
            };

        }

        private void Default_Loaded(object sender, RoutedEventArgs e)
        {
            if (NavigationContext.QueryString.Count > 0)
            {
                this.musicToPlay.Text = this.NavigationContext.QueryString.Values.First();

                try
                {
                    media.AutoPlay = true;
                    media.Source = new Uri(NavigationContext.QueryString.Values.First(), UriKind.RelativeOrAbsolute);
                    media.Position = TimeSpan.FromMilliseconds(0);
                    media.Volume = 1.0;
                    media.Play();
                }
                catch (Exception ex)
                {
                    //handle the exception;
                }
            }
        }
    }
}