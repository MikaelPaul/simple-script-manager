using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using SSM.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using SSM.View;
using static SSM.Enums;

namespace SSM.ViewModel
{
	public class MainWindowViewModel : BindableBase
	{
		private IGroupsRepository groupsRepository;

		protected const string CONFIG = "Config.json";
		public CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

		private string _SearchQuery;
		public string SearchQuery { 
			get { return _SearchQuery; }
			set 
			{ 
				_SearchQuery = value;
				OnPropertyChanged(nameof(SearchQuery));
			}
		}

		private bool _Loading = false;
		public bool Loading
		{
			get { return _Loading; }
			set
			{
				_Loading = value;
				OnPropertyChanged(nameof(Loading));
			}
		}

		//private ObservableCollection<GroupModel> _LoadedResults;
		public ObservableCollection<GroupModel> LoadedResults
		{
			get { return groupsRepository.GetGroups(); }
			set
			{
				groupsRepository.LoadGroups(value);
			}
		}

		private ObservableCollection<GroupModel> _Results;
		public ObservableCollection<GroupModel> Results {
			get { return _Results; }
			set {
				_Results = value;
			}
		}

		public MainWindowViewModel(IGroupsRepository groups)
		{
			groupsRepository = groups;

			Results = new ObservableCollection<GroupModel>();
			Results.CollectionChanged += this.OnCollectionChanged<GroupModel>;

			OpenWindowCommand = new ICommandBase<WindowType>(OnOpenWindow);

			LoadConfig();	
		}

		public async Task LoadConfig()
		{
			Loading = true;
			await Task.Run(() =>
			{
				// Create JSON Config iff not found
				var currentDirectory = Directory.GetCurrentDirectory();
				var configPath = Path.Combine(currentDirectory, CONFIG);

				if (!JsonHelper.FileExists(configPath))
				{
					JsonHelper.CreateConfigFile(currentDirectory, CONFIG);
				}

				// Read Config and deserialize into objects
				var configStream = JsonHelper.GetStreamReader(configPath);
				var groups = JsonHelper.Deserialize<ObservableCollection<GroupModel>>(configStream.BaseStream);

				if (groups == null)
					throw new Exception("Unable to deserialize the config file");

				// Sort and load into LoadedResults
				groups.Sort();
				LoadedResults = groups;
			});
			Loading = false;
		}

		public async Task Search()
		{
			

			try
			{
				// Immediatly cancel the previous token and recreate a new CancellationTokenSource
				cancellationTokenSource.Cancel();
				cancellationTokenSource = new CancellationTokenSource();

				await StartSearch(cancellationTokenSource.Token);
			}
			catch (TaskCanceledException)
			{
				Loading = false;
			}

		}

		private async Task StartSearch(CancellationToken cancellationToken)
		{
			var uiContext = SynchronizationContext.Current;
			Task task = null;

			// Start a task and return it
			task = await Task.Factory.StartNew(() =>
			{
				uiContext.Send(x => Loading = true, null);
				// Check if a cancellation is requested, if yes, throw a TaskCanceledException.
				if (cancellationToken.IsCancellationRequested)
					throw new TaskCanceledException(task);

				bool found = false;
				if (!string.IsNullOrWhiteSpace(SearchQuery))
				{
					foreach (GroupModel group in LoadedResults)
					{
						foreach (TagModel tag in group.Tags)
						{
							if (Array.IndexOf(SearchQuery.ToLower().Split(), tag.TagName.ToLower()) >= 0)
							{
								found = true;
								if (!Results.Contains(group))
								{
									uiContext.Send(x => Results.Add(group), null);
									break;
								}
							}
						}
						if (!found && Results.Contains(group))
						{
							uiContext.Send(x => Results.Remove(group), null);

						}
						found = false;
					};
				}
				else
					uiContext.Send(x => Results.Clear(), null);

				// Hide the loading icon
				uiContext.Send(x => Loading = false, null);

				return task;
			});
		}


		#region Commands

		public ICommandBase<WindowType> OpenWindowCommand { get; set; }

		private void OnOpenWindow(WindowType windowType)
		{
			AddEditGroup addView = new AddEditGroup(windowType, groupsRepository);

			switch (windowType)
			{
				case WindowType.EditGroup:
					addView.Show();
					break;
				case WindowType.AddGroup:
				default:
					addView.Show();
					break;
			}
		}

		#endregion
	}
}
