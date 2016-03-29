using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AmazingTerminal.Misc.Commands
{
    public class RelayCommandWithParameter : ICommand
    {
        private Action<object> methodToExecute;
        private Func<bool> canExecuteEvaluator;
        private ICommand TestCommand;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommandWithParameter(Action<object> methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }

        public RelayCommandWithParameter(Action<object> methodToExecute)
            : this(methodToExecute, null)
        {
        }

        public RelayCommandWithParameter(ICommand TestCommand)
        {
            this.TestCommand = TestCommand;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = this.canExecuteEvaluator.Invoke();
                return result;
            }
        }

        public void Execute(object parameter)
        {
            this.methodToExecute.Invoke(parameter);
        }
    }
}
