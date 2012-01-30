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
	public class ListMain : Object
	{
		private string _title;
		private int _amount;

		public ListMain(string title, int amount)
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
			return string.Format("ListMain title={0} amount={1}", _title, _amount);
		}
	}
}
