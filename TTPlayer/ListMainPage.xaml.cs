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
	public partial class ListMainPage : PhoneApplicationPage
	{
		// Constructor
		public ListMainPage()
		{
			InitializeComponent();
		}

		private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
		{
			List<ListMain> listData = new List<ListMain>
			{
				new ListMain("ALl Songs", 100),
				new ListMain("Artist", 40),
				new ListMain("Album", 20),
				new ListMain("xxxx", 1006),
				new ListMain("xxx", 6100)
			};
			lstMain.ItemsSource = listData;
		}

		private void lstMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ListMain selectList = lstMain.SelectedItem as ListMain;
			System.Diagnostics.Debug.WriteLine(selectList);
			if (lstMain.SelectedIndex == 0)
			{
				NavigationService.Navigate(new Uri("/ListAllSongPage.xaml", UriKind.RelativeOrAbsolute));
			}
		}
	}
}