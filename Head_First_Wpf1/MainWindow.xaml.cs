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
using System.Collections.ObjectModel;

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static string WinTitle = "Win 标题";
		public static string ShowTe { get { return "好人啊"; } }

		Student _stu;
		ObservableCollection<Student> _stulist;
		//List<Student> _stulist;

		public MainWindow()
		{
			InitializeComponent();

			_stu = new Student() { Name = "qhk" };

			//Binding binding = new Binding();
			//binding.Source = _stu;
			//binding.Path = new PropertyPath("Name");
			//BindingOperations.SetBinding(textBoxName, TextBox.TextProperty, binding);

			textBoxName.SetBinding(TextBox.TextProperty, new Binding("Name.Length"){Source = _stu, Mode=BindingMode.OneWay});

			_stulist = new ObservableCollection<Student>()
			//_stulist = new List<Student>()
			{
				new Student() {Name="Tim0", Age = 20, Id = 0},
				new Student() {Name="Tim1", Age = 21, Id = 1},
				new Student() {Name="Tim2", Age = 22, Id = 2},
				new Student() {Name="Tim3", Age = 23, Id = 3},
			};

			lbStudents.ItemsSource = _stulist;
			//lbStudents.DisplayMemberPath = "Name";
			//lbStudents.ItemTemplate = new DataTemplate(

			tbStuId.SetBinding(TextBox.TextProperty, new Binding("SelectedItem.Id") { Source = lbStudents,Mode=BindingMode.TwoWay });
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

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			_stu.Name += "Name ";
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			_stulist.Add(new Student() { Name = "Tim4", Age = 24, Id = 4 });
			//lbStudents.ItemsSource = null;
			//lbStudents.ItemsSource = _stulist;
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			_stulist[0].Name = "XXXX";
			_stulist[0].Id = 666;
			_stulist[0].Age = 88;
		}
	}
}
