using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FantasyKnapsack.Utilities
{
    public class AsyncRelayCommand : BindableBase, ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        private Func<object, Task> execute;
        private Predicate<object> canExecute;
        private bool _isAvailable = true;
        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; Notify(); }
        }
        public AsyncRelayCommand(Func<object, Task> _execute, Predicate<object> _canExecute)
        {
            execute = _execute;
            canExecute = _canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public async void Execute(object parameter)
        {
            IsAvailable = false;
            await execute(parameter);
            IsAvailable = true;
        }
    }
}
