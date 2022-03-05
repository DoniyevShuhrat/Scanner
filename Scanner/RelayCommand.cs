using System;
using System.Windows.Input;

namespace Scanner
{
    /// <summary>
    /// RelayCommand allow you to inject the command's logic via deligates passed into its constructor. This method
    /// enable ViewModels classes to implement commands in a concise manner.
    /// </summary>
    
    public class RelayCommand :ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute)
        {
            this._execute = execute;
            _canExecute = null;
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        /// <summary>
        /// CanExecuteChanged delegates the event subscription to the CommandManager.RequerySuggested event.
        /// This ensures that the WPF commanding infrastucture asks all RelayCommand object if they can whenever
        /// it asks the built-in commands.
        /// </summary>
        
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;}
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
