using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace SSM
{
	public class GroupModel
	{
		public string GroupName { get; set; }

		public ObservableCollection<TagModel> Tags = new ObservableCollection<TagModel>();

		//ICommand AddTag;
		//ICommand RemoveTag;
	}
}
