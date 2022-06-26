using BarleyBreakGameInterface.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BarleyBreakGameInterface.ViewModel.Command
{
    internal class ViewRecordsTableCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var gamePage = new RecordsPage();
            Navigator.NavigationService.Navigate(gamePage);
        }
    }
}
