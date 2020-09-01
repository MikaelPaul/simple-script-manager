using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Simple_Script_Manager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Search_KeyDown(object sender, KeyEventArgs e)
		{
			Regex acceptedKeys = new Regex(@"^[a-zA-Z0-9-_/. ]$");
			
			DebugLabel.Content = "";
			if (acceptedKeys.IsMatch(e.Key.ToString()))
				DebugLabel.Content = SearchBar.Text + e.Key.ToString();

		}
	}
}
