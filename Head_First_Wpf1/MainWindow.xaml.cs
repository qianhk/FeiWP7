using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static string WinTitle = "Win 标题";
		public static string ShowTe { get { return "好人啊"; } }
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			//StackPanel cc = this.Content as StackPanel;
			//foreach (UIElement ele in cc.Children)
			//{
			//    TextBox tb = ele as TextBox;
			//    if (tb != null)
			//    {
			//        tb.Text = string.Format("{0:%d}", tb);
			//    }
			//}

			string str = FindResource("myString") as string;
			string str2 = FindResource("myString") as string;
			textBox1.Text = str;
			textBox2.Text = str2;
		}
	}
}
