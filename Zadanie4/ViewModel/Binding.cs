using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class Binding : System.Windows.Input.ICommand
    {
        private readonly Action action;
        public event EventHandler CanExecuteChanged;

        public Binding(Action act)
        {
            this.action = act;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.action();
        }
    }
}
