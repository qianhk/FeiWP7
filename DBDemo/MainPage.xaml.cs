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
using Microsoft.Phone.Data.Linq;

namespace DBDemo
{
	public partial class MainPage : PhoneApplicationPage
	{
		private string dbPath = "isostore:/mydb.sdf";
		private const int DB_NEWEST_VERSION = 1;
		// Constructor
		public MainPage()
		{
			InitializeComponent();

			SourceData sd = new SourceData(dbPath);
			if (!sd.DatabaseExists())
			{
				sd.CreateDatabase();
				DatabaseSchemaUpdater dbUpdater = sd.CreateDatabaseSchemaUpdater();
				dbUpdater.DatabaseSchemaVersion = DB_NEWEST_VERSION;
				dbUpdater.Execute();
			}
			else
			{
				DatabaseSchemaUpdater dbUpdater = sd.CreateDatabaseSchemaUpdater();
				int oriDbVersion = dbUpdater.DatabaseSchemaVersion;
				if (oriDbVersion < 1)
				{
					dbUpdater.AddColumn<Card>("Phone");
				}
				if (oriDbVersion < DB_NEWEST_VERSION)
				{
					dbUpdater.DatabaseSchemaVersion = DB_NEWEST_VERSION;
					dbUpdater.Execute();
				}
			}
		}

		private void btnAdd_Click_1(object sender, RoutedEventArgs e)
		{
			SourceData sd = new SourceData(dbPath);
			try
			{
				Card card = new Card() { ID = 1, Name = "kai1", Email = "kai1@cc.com", Address = "地球", Phone="123" };
				Card card2 = new Card() { ID = 2, Name = "测试中文", Email = "kai2@cc.com", Address = "月亮", Phone="234" };
				sd.Cards.InsertOnSubmit(card);
				sd.Cards.InsertOnSubmit(card2);
				sd.SubmitChanges();
			}
			catch
			{
				MessageBox.Show("Data already exists");
			}
		}
		
		private void btnDel_Click_1(object sender, RoutedEventArgs e)
		{
			CardListBox.ItemsSource = null;
			SourceData sd = new SourceData(dbPath);
			var results = from item in sd.Cards select item;
			foreach (var i in results)
			{
				sd.Cards.DeleteOnSubmit(i);
			}
			sd.SubmitChanges();
		}

		private void btnDis_Click_1(object sender, RoutedEventArgs e)
		{
			SourceData sd = new SourceData(dbPath);
			var results = from item in sd.Cards select item;
			foreach (var item in results)
			{
				System.Diagnostics.Debug.WriteLine("item=" + item);
			}
			CardListBox.ItemsSource = results.ToList();
		}
	}
}