using BarleyBreakGameInterface.ViewModel.Command;
using BarleyBreakGameInterface.Model.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BarleyBreakGameInterface.Service;

namespace BarleyBreakGameInterface.ViewModel
{
    public class MainMenuViewModel
    {

        ICommand changeStyle;
        public ICommand ChangeStyle
        {
            get
            {
                return changeStyle ?? new ChangeStyleCommand(StyleStratgyHolder.Instance);
            }
        }

        public ICommand StartGame { get; } = new StartGameCommand();

        public ICommand Exit { get; } = new ExitCommand();

        public ICommand ViewRecordsTable { get; } = new ViewRecordsTableCommand();
    }
}
