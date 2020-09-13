using Microsoft.EntityFrameworkCore;
using SSM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SSM
{
    /// <summary>
    /// I would like to use DbContext for it's asynchronous functionality, however I'm not conviced that I was to use a database as I'd like to
    /// keep everything in memory and "Saved" to a JSON with user intervention. In the future if I find a way to abstract DbContext for 
    /// implementation by a JsonWriter, then I may refactor my code and begin using this class once again.
    /// </summary>
	public class GroupsDbContext : DbContext
	{

		public GroupsDbContext() : base()
        {
            // Requires that the Database exists - I don't want to use a database however for performance reasons
            //Database.EnsureCreated();
        }

        public DbSet<GroupModel> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupModel>().HasData(GetAllGroups());
            base.OnModelCreating(modelBuilder);
        }

        public ObservableCollection<GroupModel> GetAllGroups()
        {
            return Groups.Local.ToObservableCollection();
        }


    }
}
