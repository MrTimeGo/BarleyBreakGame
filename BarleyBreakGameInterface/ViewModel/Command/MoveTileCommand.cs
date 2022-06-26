using BarleyBreakGameInterface.Model;
using BarleyBreakGameInterface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BarleyBreakGameInterface.ViewModel.Command
{
    internal class MoveTileCommand : ICommand
    {
        MatrixHadler handler;

        public Record Record { get; set; }

        public MoveTileCommand(MatrixHadler handler)
        {
            this.handler = handler;
        }

        public event EventHandler? CanExecuteChanged;

        public void Execute(object? parameter)
        {
            ArgumentNullException.ThrowIfNull(parameter, nameof(parameter));
            string content = parameter.ToString();
            bool result = handler.Handle(content);
            if (result)
            {
                Record.StepsConter++;
            }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }
    }
}
