using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace SSM
{
	public class ResultViewModel : INotifyPropertyChanged
	{
		private ResultModel Result;

		private string _SearchQuery;
		public string SearchQuery { 
			get { return _SearchQuery; }
			set { _SearchQuery = value; Search(); }
		}

		public ObservableCollection<GroupModel> Groups {
			get { return Result.Groups; }
			set {
				Result.Groups = value;
				OnPropertyChanged(nameof(Groups));
			}
		}

		public ResultViewModel()
		{
			Result = new ResultModel();
			Groups = new ObservableCollection<GroupModel>();

			Groups.CollectionChanged += this.OnCollectionChanged;
		}

		private void Search()
		{
			// Temp code simulating the retrival of results
			for(int i = 0; i < SearchQuery.Length; i++)
			{
				GroupModel group = new GroupModel() { GroupName = $"Group {i}" };

				TagModel tag = new TagModel() { TagName = $"Tag {i}" };

				group.Tags.Add(tag);

				Groups.Add(group);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			//Get the sender observable collection
			ObservableCollection<string> obsSender = sender as ObservableCollection<string>;

			List<GroupModel> editedOrRemovedItems = new List<GroupModel>();
			foreach (GroupModel newItem in e.NewItems)
			{
				editedOrRemovedItems.Add(newItem);
			}

			if (e.OldItems != null)
				foreach (GroupModel oldItem in e.OldItems)
				{
					editedOrRemovedItems.Add(oldItem);
				}

			//Get the action which raised the collection changed event
			NotifyCollectionChangedAction action = e.Action;
		}

	}
}
