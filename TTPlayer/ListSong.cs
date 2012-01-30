using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TTPlayer
{
	public class ListSong
	{
		string _artist;
		string _title;
		string _album;

		public ListSong(string artist, string title, string album)
		{
			_artist = artist;
			_title = title;
			_album = album;
		}

		public string Title
		{
			get
			{
				return _title;
			}
		}

		public string ArtistAlbum
		{
			get
			{
				return _artist + " - " + _album;
			}
		}
	}
}
