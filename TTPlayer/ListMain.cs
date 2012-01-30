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
		protected string _title;
		protected int _amount;

		public ListNormal(string title, int amount)
		{
			_title = title;
			_amount = amount;
		}

		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
			}
		}

		public string AmountString
		{
			get
			{
				return string.Format("共 {0} 首歌", _amount);
			}
		}

		public override string ToString()
		{
			return string.Format("ListNormal title={0} amount={1}", _title, _amount);
		}
	}

	public class ListAll : ListNormal
	{
		public ListAll(string title, int amount) : base(title, amount)
		{
		}
	}

	public class ListArtist : ListNormal
	{
		public ListArtist(string title, int amount) : base(title, amount)
		{
		}

		public string AmountString
		{
			get
			{
				return string.Format("共 {0} 个歌手", _amount);
			}
		}

		public override string ToString()
		{
			return string.Format("ListArtist title={0} amount={1}", _title, _amount);
		}
	}

	public class ListAlbum : ListNormal
	{
		public ListAlbum(string title, int amount)
			: base(title, amount)
		{
		}

		public string AmountString
		{
			get
			{
				return string.Format("共 {0} 个专辑", _amount);
			}
		}

		public override string ToString()
		{
			return string.Format("ListAlbum title={0} amount={1}", _title, _amount);
		}
	}
}
