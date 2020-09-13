using SSM.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSM.ViewModel
{
	public class AddEditGroupViewModel : BindableBase
	{
		private IGroupsRepository groupsRepository;

		private GroupModel _Group;
		public GroupModel Group 
		{
			get { return _Group; }
			set
			{
				_Group = value;
				OnPropertyChanged(nameof(Group));
			}
		}

		public AddEditGroupViewModel(IGroupsRepository groups)
		{
			groupsRepository = groups;
		}


	}
}
