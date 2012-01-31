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
	public partial class ListAlbumPage : PhoneApplicationPage
	{
		public ListAlbumPage()
		{
			InitializeComponent();
		}

		private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
		{
			App app = Application.Current as App;
			var listAlbum = from Album album in app.library.Albums
							select new ListAlbum(album.Name, album.Songs.Count);
			lstAllAlbum.ItemsSource = listAlbum;
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}

		private void btnToPlayView_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/PlayMain.xaml", UriKind.Relative));
		}

		private void lstAllAlbum_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (lstAllAlbum.SelectedIndex < 0)
			{
				return;
			}

			ListAlbum album = lstAllAlbum.SelectedItem as ListAlbum;
			string url = string.Format("/ListSongPage.xaml?type=album&albumIndex={0}&album={1}", lstAllAlbum.SelectedIndex, "专 辑&X");
			NavigationService.Navigate(new Uri(url, UriKind.RelativeOrAbsolute));
		}
	}
}