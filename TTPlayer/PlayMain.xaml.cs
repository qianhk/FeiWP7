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
using System.Windows.Navigation;
using Microsoft.Xna.Framework.Media;
using System.Windows.Threading;
using System.Threading;

namespace TTPlayer
{
	public partial class PlayMain : PhoneApplicationPage
	{
		private App _app = Application.Current as App;
		private DispatcherTimer _timer = new DispatcherTimer();
		int _timejs = 0;

		public PlayMain()
		{
			InitializeComponent();
			privotPlay.Title = null;
			pivotItemMain.Header = null;
			pivotItemLyric.Header = null;
			//privotPlay.SelectedIndex = 1;

			MediaPlayer.MediaStateChanged += new EventHandler<EventArgs>(MediaPlayer_MediaStateChanged);
			MediaPlayer.ActiveSongChanged += MediaPlayer_ActiveMediaChanged;

			_timer.Interval = TimeSpan.FromMilliseconds(50);
			_timer.Tick += TimeCallBack;
		}

		private void SetControlState()
		{
			System.Diagnostics.Debug.WriteLine("SetControlState PlayMain PlayState={0}", MediaPlayer.State.ToString());
			switch (MediaPlayer.State)
			{
				case MediaState.Playing:
					btnPlayPause.Content = "Pause";
					if (!_timer.IsEnabled)
					{
						_timer.Start(); ;
					}
					break;
				case MediaState.Paused:
				case MediaState.Stopped:
					btnPlayPause.Content = "Play";
					if (_timer.IsEnabled)
					{
						_timer.Stop(); ;
					}
					break;
			}
			Song song = _app.CurPlaySong;
			if (song != null)
			{
				tbArtist.Text = song.Artist.Name;
				tbTitle.Text = song.Name;
				tbAlbum.Text = song.Album.Name;
				tbDuration.Text = song.Duration.ToString(@"mm\:ss");
			}
		}

		void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
		{
			SetControlState();
		}

		void MediaPlayer_ActiveMediaChanged(object sender, EventArgs e)
		{
			//_app.curPlaySongIndex = MediaPlayer.
			System.Diagnostics.Debug.WriteLine(e);
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}

		private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Page_Loaded PlayMain");

			Song song = _app.CurPlaySong;
			if (song != null)
			{
				tbArtist.Text = song.Artist.Name;
				tbTitle.Text = song.Name;
				tbAlbum.Text = song.Album.Name;
				tbDuration.Text = song.Duration.ToString(@"mm\:ss");

				if (NavigationContext.QueryString.Count > 0)
				{
					MediaPlayer.Play(_app.curPlaySongCollection, _app.curPlaySongIndex);
				}
			}
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			_timer.Stop();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			//System.Diagnostics.Debug.WriteLine("OnNavigatedTo PlayMain ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
			SetControlState();
			tbCurTime.Text = MediaPlayer.PlayPosition.ToString(@"mm\:ss");
		}

		private void TimeCallBack(object sender, EventArgs e)
		{
			//System.Diagnostics.Debug.WriteLine("PlayMain TimeCallBack ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
			++_timejs;
			if (_timejs > 10)
			{
				tbCurTime.Text = MediaPlayer.PlayPosition.ToString(@"mm\:ss");
				_timejs = 0;
			}
		}

		private void btnPlayPause_Click(object sender, RoutedEventArgs e)
		{
			//MessageBox.Show("xxxxx", "caption", MessageBoxButton.OKCancel);
			if (_app.CurPlaySong != null)
			{
				if (MediaPlayer.State == MediaState.Playing)
				{
					MediaPlayer.Pause();
				}
				else
				{
					MediaPlayer.Resume();
				}
			}
		}

		private void btnPre_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnNext_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}