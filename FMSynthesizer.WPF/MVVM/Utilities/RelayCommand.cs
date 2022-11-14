using System;
using System.Windows.Input;

namespace FMSynthesizer.WPF.MVVM.Utilities
{
    internal class RelayCommand : ICommand
    {
        private Action<object?>? _execute;
        private Func<object?, bool>? _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add    { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action execute) : this(obj => execute())
        {
        }

        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;
        public void Execute(object? parameter) => _execute?.Invoke(parameter);
    }
}
