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
	public partial class PlayMain : PhoneApplicationPage
	{
		public PlayMain()
		{
			InitializeComponent();
			privotPlay.Title = null;
			pivotItemMain.Header = null;
			pivotItemLyric.Header = null;
			//privotPlay.SelectedIndex = 1;
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}
	}
}