using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WpfApplication1
{
	class Student : INotifyPropertyChanged
	{
		string name;
		int _id;
		int _age;

		public event PropertyChangedEventHandler PropertyChanged;

		public int Age
		{
			get
			{
				return _age;
			}
			set
			{
				_age = value;
				if (PropertyChanged != null)
				{
					PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Age"));
				}
			}
		}

		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
				if (PropertyChanged != null)
				{
					PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Id"));
				}
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
				if (PropertyChanged != null)
				{
					PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
				}
			}
		}
	}
}
