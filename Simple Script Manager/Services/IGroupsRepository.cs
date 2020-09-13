using SSM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SSM
{
	public interface IGroupsRepository
	{
		ObservableCollection<GroupModel> GetGroups();
		Task<GroupModel> GetGroupAsync(string id);
		Task<GroupModel> AddGroupAsync(GroupModel customer);
		Task<GroupModel> UpdateGroupAsync(GroupModel customer);
		Task DeleteGroupAsync(string groupId);
		void LoadGroups(ObservableCollection<GroupModel> groups);
	}
}
