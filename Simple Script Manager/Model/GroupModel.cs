using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace SSM.Model
{
	public class GroupModel : IComparable
	{
		public string GroupName { get; set; }

		public List<TagModel> Tags { get; set; } = new List<TagModel>();

		public List<FileModel> Files { get; set; } = new List<FileModel>();

		public int CompareTo(object o) => string.Compare(this.GroupName, ((GroupModel)o).GroupName, true);

		//ICommand AddGroup;
		//ICommand RemoveGroup;
	}
}
