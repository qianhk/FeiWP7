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
using System.Collections.ObjectModel;
using WindowsPhoneNavigation.Misc;
using Microsoft.Phone.Shell;

namespace WindowsPhoneNavigation.Views.Pictures
{
    public partial class Default : PhoneApplicationPage
    {
        ObservableCollection<Photo> photos = new ObservableCollection<Photo>();

        public Default()
        {
            InitializeComponent();

            InitializePhotos();
            lstPictures.ItemsSource = photos;
            (ApplicationBar.MenuItems[0] as ApplicationBarMenuItem).Click += new EventHandler(ApplicationBar_OnClick);
        }

        private void InitializePhotos()
        {
            photos.Add(new Photo()
            {
                Filename = "Butterfly.jpg",
                Image = Utils.GetImage("Butterfly.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Chrysanthemum.jpg",
                Image = Utils.GetImage("Chrysanthemum.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Desert.jpg",
                Image = Utils.GetImage("Desert.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Field.jpg",
                Image = Utils.GetImage("Field.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Flower.jpg",
                Image = Utils.GetImage("Flower.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Hydrangeas.jpg",
                Image = Utils.GetImage("Hydrangeas.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Jellyfish.jpg",
                Image = Utils.GetImage("Jellyfish.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Koala.jpg",
                Image = Utils.GetImage("Koala.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Leaves.jpg",
                Image = Utils.GetImage("Leaves.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Lighthouse.jpg",
                Image = Utils.GetImage("Lighthouse.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Penguins.jpg",
                Image = Utils.GetImage("Penguins.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Rocks.jpg",
                Image = Utils.GetImage("Rocks.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Tulip.jpg",
                Image = Utils.GetImage("Tulip.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Tulips.jpg",
                Image = Utils.GetImage("Tulips.jpg")
            });
            photos.Add(new Photo()
            {
                Filename = "Window.jpg",
                Image = Utils.GetImage("Window.jpg")
            });
        }

        private void btnRemoveSelection_Click(object sender, RoutedEventArgs e)
        {
            if (null != lstPictures.SelectedItem)
                photos.Remove(lstPictures.SelectedItem as Photo);
        }

        private void lstPictures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (null != lstPictures.SelectedItem)
            {
                btnRemoveSelection.IsEnabled = true;
                this.ApplicationBar.IsVisible = true;
            }

            if (photos.Count == 0)
            {
                btnRemoveSelection.IsEnabled = false;
                this.ApplicationBar.IsVisible = false;
            }
        }

        private void ApplicationBar_OnClick(object sender, EventArgs e)
        {
            if (null != lstPictures.SelectedItem)
            {
                PhoneApplicationFrame root = Application.Current.RootVisual as PhoneApplicationFrame;
                root.Navigate(new Uri("/PictureView/" + (lstPictures.SelectedItem as Photo).Filename, UriKind.Relative));
            }
        }
    }
}