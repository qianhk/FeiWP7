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
	public partial class ListSongPage : PhoneApplicationPage
	{
		private SongCollection _songs;

		public ListSongPage()
		{
			InitializeComponent();
		}

		private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
		{
			//List<ListSong> allSong = new List<ListSong>()
			//{
			//    new ListSong("artist1", "title5", "album1"),
			//    new ListSong("artist2", "title6", "album2"),
			//    new ListSong("artist3", "title7", "album3"),
			//    new ListSong("artist4", "title8", "album4")
			//};
			//lstAllSong.ItemsSource = allSong;
			App app = Application.Current as App;
			if (NavigationContext.QueryString.Count == 0)
			{
				tbTitle.Text = "All Songs";
				SongToList(app.library.Songs);
			}
			else
			{
				string type = NavigationContext.QueryString["type"];
				switch (type)
				{
					case "artist":
						{
							int index = int.Parse(NavigationContext.QueryString["artistIndex"]);
							string artist = NavigationContext.QueryString["artist"];
							tbTitle.Text = artist;
							SongToList(app.library.Artists[index].Songs);
						}
						break;

					case "album":
						{
							int index = int.Parse(NavigationContext.QueryString["albumIndex"]);
							string album = NavigationContext.QueryString["album"];
							tbTitle.Text = album;
							SongToList(app.library.Albums[index].Songs);
						}
						break;
				}
				
			}
		}

		private void SongToList(SongCollection songs)
		{
			_songs = songs;
			var allSong = from Song song in songs
						  select new ListSong(song.Artist.Name, song.Name, song.Album.Name);
			lstSongs.ItemsSource = allSong;
		}

		private void lstSongs_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (lstSongs.SelectedIndex < 0)
			{
				return;
			}

			//ListSong song = lstSongs.SelectedItem as ListSong;
			App app = Application.Current as App;
			app.curPlaySong = _songs[lstSongs.SelectedIndex];
			NavigationService.Navigate(new Uri("/PlayMain.xaml?action=play", UriKind.Relative));
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}

		private void btnToPlayView_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new Uri("/PlayMain.xaml", UriKind.Relative));
		}
	}
}