﻿using System;
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

namespace SSM
{
	/// <summary>
	/// Interaction logic for ResultView.xaml
	/// </summary>
	public partial class ResultView : UserControl
	{
		public string GroupName { 
			get { return GroupNameLabel.Content.ToString(); } 
			set { GroupNameLabel.Content = value; } 
		}


		public ResultView()
		{
			InitializeComponent();
		}

		
	}
}
