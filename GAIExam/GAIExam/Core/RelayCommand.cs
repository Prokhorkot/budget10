using System;
using System.Windows.Input;

namespace GAIExam.Core
{
    class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(null) || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {

            _execute = Execute;
            _canExecute = CanExecute;

        }
    }
}
