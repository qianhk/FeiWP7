using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace DBDemo
{
	[Table]
	public class Card
	{
		[Column (IsPrimaryKey=true)]
		public int ID { get; set; }

		[Column]
		public string Name { get; set; }

		[Column]
		public string Email { get; set; }

		[Column]
		public string Address { get; set; }

		[Column]
		public string Phone { get; set; }
	}

	public class SourceData : DataContext
	{
		public Table<Card> Cards;
		public SourceData(string connectString) : base(connectString)
		{
			
		}
	}
}
