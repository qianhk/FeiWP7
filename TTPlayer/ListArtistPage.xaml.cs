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
using Microsoft.Xna.Framework.Media;

namespace TTPlayer
{
	public partial class ListArtistPage : PhoneApplicationPage
	{
		public ListArtistPage()
		{
			InitializeComponent();
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}

		private void btnToPlayView_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/PlayMain.xaml", UriKind.Relative));
		}

		private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
		{
			App app = Application.Current as App;
			var allArtist = from Artist artist in app.library.Artists
						  select new ListArtist(artist.Name, artist.Songs.Count);
			lstAllArtist.ItemsSource = allArtist;
		}

		private void lstAllArtist_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (lstAllArtist.SelectedIndex < 0)
			{
				return;
			}

			ListArtist artist = lstAllArtist.SelectedItem as ListArtist;
			string url = string.Format("/ListSongPage.xaml?type=artist&artistIndex={0}&artist={1}", lstAllArtist.SelectedIndex, artist.Name);
			NavigationService.Navigate(new Uri(url, UriKind.RelativeOrAbsolute));
		}
	}
}