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
	public class ListNormal : Object
	{
		protected string _name;
		protected int _amount;

		public ListNormal(string title, int amount)
		{
			_name = title;
			_amount = amount;
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		virtual public string AmountString
		{
			get
			{
				return string.Format("共 {0} 首歌", _amount);
			}
		}

		public override string ToString()
		{
			return string.Format("ListNormal title={0} amount={1}", _name, _amount);
		}
	}

	public class ListAllAll : ListNormal
	{
		public ListAllAll(string title, int amount) : base(title, amount)
		{
		}
	}

	public class ListAllArtist : ListNormal
	{
		public ListAllArtist(string title, int amount) : base(title, amount)
		{
		}

		override public string AmountString
		{
			get
			{
				return string.Format("共 {0} 个歌手", _amount);
			}
		}

		public override string ToString()
		{
			return string.Format("ListAllArtist title={0} amount={1}", _name, _amount);
		}
	}

	public class ListAllAlbum : ListNormal
	{
		public ListAllAlbum(string title, int amount)
			: base(title, amount)
		{
		}

		override public string AmountString
		{
			get
			{
				return string.Format("共 {0} 张专辑", _amount);
			}
		}

		public override string ToString()
		{
			return string.Format("ListAllAlbum title={0} amount={1}", _name, _amount);
		}
	}

	public class ListArtist : ListNormal
	{
		public ListArtist(string artist, int amount)
			: base(artist, amount)
		{
		}

		public override string ToString()
		{
			return string.Format("ListArtist artist={0} amount={1}", _name, _amount);
		}
	}

	public class ListAlbum : ListNormal
	{
		public ListAlbum(string album, int amount)
			: base(album, amount)
		{
		}

		public override string ToString()
		{
			return string.Format("ListAlbum album={0} amount={1}", _name, _amount);
		}
	}
}
