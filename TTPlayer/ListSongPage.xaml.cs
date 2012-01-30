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

namespace TTPlayer
{
	public partial class ListSongPage : PhoneApplicationPage
	{
		public ListSongPage()
		{
			InitializeComponent();
		}

		private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
		{
			List<ListSong> allsong = new List<ListSong>()
			{
				new ListSong("artist", "title", "album"),
				new ListSong("artist", "title", "album"),
				new ListSong("artist", "title", "album"),
				new ListSong("artist", "title", "album")
			};
			lstAllSong.ItemsSource = allsong;
		}

		private void lstAllSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

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