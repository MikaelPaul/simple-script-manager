using SSM.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static SSM.Enums;

namespace SSM.View
{
	/// <summary>
	/// Interaction logic for AddEditGroup.xaml
	/// </summary>
	public partial class AddEditGroup : Window
	{
		private IGroupsRepository groupsRepository;
		private readonly AddEditGroupViewModel AddEditGroupViewModel;

		public AddEditGroup(WindowType windowType, IGroupsRepository groups)
		{
			InitializeComponent();

			groupsRepository = groups;

			// Initialize and data-bind to ViewModel
			AddEditGroupViewModel = new AddEditGroupViewModel(groups);
			this.DataContext = AddEditGroupViewModel;

			// Set UI title
			if (windowType == WindowType.AddGroup)
				this.Title = "Add Group";
			else if (windowType == WindowType.EditGroup)
				this.Title = "Edit Group";
		}
	}
}
