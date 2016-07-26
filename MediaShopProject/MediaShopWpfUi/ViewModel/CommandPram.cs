using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaShopWpfUi.ViewModel
{
    public class CommandPram<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;
        public event EventHandler CanExecuteChanged;
        public CommandPram(Action<T> execute, Func<T, bool> canexecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canexecute ?? (e => true);
        }
        [DebuggerStepThrough]
        public bool CanExecute(object p)
        {
            try
            {
                var _Value = (T)Convert.ChangeType(p, typeof(T));
                return _canExecute == null ? true : _canExecute(_Value);
            }
            catch { return false; }
        }
        public void Execute(object p)
        {
            if (!CanExecute(p))
                return;
            var _Value = (T)Convert.ChangeType(p, typeof(T));
            _execute(_Value);
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged.Invoke(this, EventArgs.Empty);
        }
    }
}
