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
/*
 
 MainWindow (View) data-binded to ResultViewModel (ViewModel) and update Search Property, asynchronously querying JSON for a match (loop through groups, then loop through tags)

-- A ViewModel is the controller of events and logic

ResultViewModel
	- Iterate JSON async for associated groups and tags. Matches will raise events up to the controller and the controller will data-bind the Models/Views

-- A model is a continer of data (no business logic)

ResultModel {List<Groups>} -> ClearGroups()
GroupModel {GroupName and List<Tags>}
TagModel {TagName}




Identify all files with associated tags (JSON)
Identify all files with associated keywords (File System) (Future version)


 */

namespace SSM
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public User user;

		private readonly ResultViewModel ViewModel;
		//private List<ResultView> results = new List<ResultView>();

		public MainWindow()
		{
			InitializeComponent();

			user = new User("Mikael");

			// Data-bind to ViewModel
			ViewModel = new ResultViewModel();
			this.DataContext = this;

			/*AddResult();
			AddResult();
			AddResult();
			AddResult();*/
		}

		private void Search_KeyUp(object sender, KeyEventArgs e)
		{
			//ViewModel.SearchQuery = SearchBar.Text;

			/*Regex acceptedKeys = new Regex(@"^[a-zA-Z0-9-_/. ]$");
			
			DebugLabel.Content = "";
			if (acceptedKeys.IsMatch(e.Key.ToString()))
				DebugLabel.Content = SearchBar.Text + e.Key.ToString();*/

		}

		/*private void AddResult()
		{
			ResultPanel.Children.Add(new ResultView() { GroupName = "This is a result" });
			ResultPanel.Children.Add(new Separator() { Height = 1, Margin = new Thickness(10, 0, 10, 0) });
		}*/

		public class User
		{
			public string Name;

			public User(string name)
			{
				Name = name;
			}
		}
	}
}
