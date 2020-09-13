using SSM.Model;
using SSM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SSM.View.UserControls
{
	public partial class ResultView : UserControl
	{
		//private readonly AddEditGroupViewModel AddEditGroupViewModel;

		public ResultView()
		{
			InitializeComponent();
			Console.WriteLine($"DataContext of ResultView is {DataContext}");
			// Initialize and data-bind to ViewModel
			//AddEditGroupViewModel = new AddEditGroupViewModel();
			//this.DataContext = AddEditGroupViewModel;
		}

	}
}
