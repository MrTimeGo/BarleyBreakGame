using BarleyBreakGameInterface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BarleyBreakGameInterface.ViewModel.Command
{
    public class ChangeStyleCommand : ICommand
    {
        StyleStratgyHolder styleStratgy;

        public ChangeStyleCommand(StyleStratgyHolder styleStratgyHolder)
        {
            this.styleStratgy = styleStratgyHolder;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        Random rand = new Random();

        public void Execute(object? parameter)
        {
            styleStratgy.Next();
        }
    }
}
