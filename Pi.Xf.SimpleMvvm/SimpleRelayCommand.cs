using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pi.Xf.SimpleMvvm
{
    public sealed class SimpleRelayCommand : ICommand
    {
        private readonly Action _executeAction;
        private readonly Func<object, bool> _canExecuteFunc;

        public event EventHandler CanExecuteChanged;

        public SimpleRelayCommand(Action executeAction)
        {
            _executeAction = executeAction;
        }

        public SimpleRelayCommand(Action executeAction, Func<object, bool> canExecuteFunc) : this(executeAction)
        {
            _canExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteFunc?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _executeAction?.Invoke();
        }
    }

    public sealed class SimpleRelayCommand<TE> : ICommand
    {
        private readonly Action<TE> _executeAction;
        private readonly Func<TE, bool> _canExecuteFunc;

        public event EventHandler CanExecuteChanged;

        public SimpleRelayCommand(Action<TE> executeAction)
        {
            _executeAction = executeAction;
        }

        public SimpleRelayCommand(Action<TE> executeAction, Func<TE, bool> canExecuteFunc) : this(executeAction)
        {
            _canExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteFunc?.Invoke((TE)parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _executeAction?.Invoke((TE)parameter);
        }
    }
}
