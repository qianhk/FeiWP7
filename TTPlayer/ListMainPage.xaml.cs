﻿using System;
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
using Microsoft.Xna.Framework.Media;

namespace TTPlayer
{
	public partial class ListMainPage : PhoneApplicationPage
	{
		// Constructor
		public ListMainPage()
		{
			InitializeComponent();
		}

		private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
		{
			App app = Application.Current as App;
			MediaLibrary library = app.library;

			List<ListNormal> listData = new List<ListNormal>
			{
			    new ListAllAll("ALl Songs", library.Songs.Count),
			    new ListAllArtist("Artist", library.Artists.Count),
			    new ListAllAlbum("Album", library.Albums.Count),
			};
			lstMain.ItemsSource = listData;
		}

		private void lstMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (lstMain.SelectedIndex < 0)
			{
				return;
			}
	
			ListNormal selectList = lstMain.SelectedItem as ListNormal;
			System.Diagnostics.Debug.WriteLine(selectList);
			string[] url = { "/ListSongPage.xaml", "/ListArtistPage.xaml", "/ListAlbumPage.xaml" };
			if (lstMain.SelectedIndex < url.Count())
			{
				NavigationService.Navigate(new Uri(url[lstMain.SelectedIndex], UriKind.RelativeOrAbsolute));
			}
		}

		private void btnToPlayView_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/PlayMain.xaml", UriKind.Relative));
		}
	}
}