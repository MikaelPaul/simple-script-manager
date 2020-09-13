using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace SSM
{
    public class BindableBase : INotifyPropertyChanged, INotifyCollectionChanged
    {
		#region NotifyPropertyChanged

		protected virtual void SetProperty<T>(ref T member, T val, string propertyName = null)
        {
            if (object.Equals(member, val)) return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

		#endregion

		#region NotifyCollectionChanged

		public void OnCollectionChanged<T>(object sender, NotifyCollectionChangedEventArgs e)
		{
			List<T> editedOrRemovedItems = new List<T>();
			if (e.NewItems != null)
				foreach (T newItem in e.NewItems)
				{
					editedOrRemovedItems.Add(newItem);
				}

			if (e.OldItems != null)
				foreach (T oldItem in e.OldItems)
				{
					editedOrRemovedItems.Add(oldItem);
				}

			// Get the action which raised the collection changed event
			NotifyCollectionChangedAction action = e.Action;
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged = delegate { };

		#endregion
	}

}
