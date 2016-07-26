using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaShopWpfUi.ViewModel
{
    public class Command: ICommand
    {
        
            private readonly Action _execute;
            private readonly Func<bool> _canExecute;
            public event EventHandler CanExecuteChanged;

            public Command(Action execute, Func<bool> canExecute = null)
            {
                if (execute == null)
                {
                    throw new ArgumentNullException("NUll given");
                }

                _execute = execute;
                _canExecute = canExecute ?? (() => true);
            }

            [DebuggerStepThrough]
            public bool CanExecute(object p)
            {
                try
                {
                    return _canExecute();
                }
                catch (Exception)
                {

                    return false;
                }
            }

            public void Execute(object p)
            {
                if (!CanExecute(p))
                {
                    return;
                }

                try
                {
                    _execute();
                }
                catch (Exception)
                {

                    Debugger.Break();
                }
            }

            public void RaiseCanExecuteChange()
            {
                CanExecuteChanged.Invoke(this, EventArgs.Empty);
            }
        }
    }

