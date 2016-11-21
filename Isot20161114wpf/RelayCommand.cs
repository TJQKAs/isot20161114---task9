using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Isot20161114wpf
{
    // инетрефейс добавления комманд
    public class RelayCommand : ICommand
    {  // делегаты 
        private Action<object> execute;
        private Func<object, bool> canExecute;
    // может ли комманда выполняться 
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
        // методу передается параметр 
        public void Execute(object parameter)
        {   // вызываетя  делегат 
            this.execute(parameter);
        }
    }
}
