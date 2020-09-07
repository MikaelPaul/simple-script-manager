using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace SSM
{
	public class ResultModel
	{
		public ObservableCollection<GroupModel> Groups = new ObservableCollection<GroupModel>();

		ICommand AddGroup;
		ICommand RemoveGroup;
	}
}
