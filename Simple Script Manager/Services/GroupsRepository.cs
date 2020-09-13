using Microsoft.EntityFrameworkCore;
using SSM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSM
{
    /// <summary>
    /// Repository of all groups loaded form a file. 
    /// 
    /// The methods are not truly asynchronous as I couldn't get the DbContext figured out.
    /// </summary>
    public class GroupsRepository : IGroupsRepository
    {
        //GroupsDbContext _context = new GroupsDbContext();

        public ObservableCollection<GroupModel> Groups { get; set; }

        public ObservableCollection<GroupModel> GetGroups()
        {
            //Task<ObservableCollection<GroupModel>> task = null;

            //task = Task.Factory.StartNew(() =>
            //{
            //    _context.GetAllGroups();
            //}) as Task<ObservableCollection<GroupModel>>;
            //return task;

            //return _context.GetAllGroups();

            return Groups;
        }

        public Task<GroupModel> GetGroupAsync(string id)
        {
            Task<GroupModel> task = null;
            task = Task.Factory.StartNew(() =>
            {
                Groups.FirstOrDefault(g => g.GroupName == id);
            }) as Task<GroupModel>;
            return task;

            //return _context.Groups.FirstOrDefaultAsync(g => g.GroupName == id);
        }

        public Task<GroupModel> AddGroupAsync(GroupModel group)
        {
            Task<GroupModel> task = null;
            task = Task.Factory.StartNew(() =>
            {
                Groups.Add(group);
            }) as Task<GroupModel>;
            return task;

            //_context.Groups.Add(group);
            //await _context.SaveChangesAsync();
            //return group;
        }

        public Task<GroupModel> UpdateGroupAsync(GroupModel group)
        {

            Task<GroupModel> task = null;
            task = Task.Factory.StartNew(() =>
            {
                if (!Groups.Any(c => c.GroupName == group.GroupName))
                {
                    Groups.Add(group);
                }
            }) as Task<GroupModel>;
            return task;

            //if (!_context.Groups.AnyAsync(c => c.GroupName == group.GroupName).Result)
            //{
            //    _context.Groups.Attach(group);
            //}

            //_context.Entry(group).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            //return group;
        }

        public Task DeleteGroupAsync(string groupId)
        {
            Task<GroupModel> task = null;
            task = Task.Factory.StartNew(() =>
            {
                var group = Groups.FirstOrDefault(g => g.GroupName == groupId);

                if (group != null)
                {
                    Groups.Remove(group);
                }
            }) as Task<GroupModel>;
            return task;

            //var group = _context.Groups.FirstOrDefaultAsync(g => g.GroupName == groupId);

            //if (group != null)
            //{
            //    _context.Groups.Remove(group.Result);
            //}

            //await _context.SaveChangesAsync();
        }

        public void LoadGroups(ObservableCollection<GroupModel> groups)
        {
            Groups = groups;

            //foreach (GroupModel group in groups)    
            //    _context.Groups.Add(group);
        }
    }
}
