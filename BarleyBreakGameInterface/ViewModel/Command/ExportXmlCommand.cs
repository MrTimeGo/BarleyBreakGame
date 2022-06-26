using BarleyBreakGameInterface.Dao;
using BarleyBreakGameInterface.Model;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BarleyBreakGameInterface.ViewModel.Command
{
    internal class ExportXmlCommand : ICommand
    {
        DataFileTemplate dataFile;

        public ExportXmlCommand(DataFileTemplate dataFile)
        {
            this.dataFile = dataFile;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var dialog = new VistaFolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                var filepath = dialog.SelectedPath + "\\" + DateTime.Now.ToFileTime() + ".xml";
                dataFile.FileName = filepath;
                dataFile.InsertRecords((IEnumerable<Record>)parameter);
            }
        }
    }
}
