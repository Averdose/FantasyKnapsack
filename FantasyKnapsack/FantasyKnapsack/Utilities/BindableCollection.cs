using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyKnapsack.Utilities
{
    public class BindableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
            {
                RegisterItems(e.NewItems);
            }
            if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace)
            {
                UnregisterItems(e.OldItems);
            }
            base.OnCollectionChanged(e);
        }

        private void RegisterItems(IList items)
        {
            foreach (object item in items)
            {
                (item as INotifyPropertyChanged).PropertyChanged += OnPropertyChanged;
            }
        }

        private void UnregisterItems(IList items)
        {
            foreach (object item in items)
            {
                (item as INotifyPropertyChanged).PropertyChanged -= OnPropertyChanged;
            }
        }

        protected void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            base.OnCollectionChanged(args);
        }
    }
}
