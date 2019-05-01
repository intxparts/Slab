using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Slab
{
    public class DelegateCommand : ICommand
    {
        private Action _action;
        private Func<bool> _canExecuteCb;

        public DelegateCommand(Action action)
            : this(action, () => true)
        {
        }

        public DelegateCommand(Action action, Func<bool> canExecuteCB)
        {
            _action = action;
            _canExecuteCb = canExecuteCB;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteCb.Invoke();
        }

        public void Execute(object parameter)
        {
            _action.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }
}
