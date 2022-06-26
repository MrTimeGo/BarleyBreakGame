using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using BarleyBreakGameInterface.Dao;
using BarleyBreakGameInterface.Model;

namespace BarleyBreakGameInterface.ViewModel.Command
{
    internal class ExportJsonCommand : ICommand
    {
        DataFileTemplate dataFile;

        public ExportJsonCommand(DataFileTemplate dataFile)
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
                var filepath = dialog.SelectedPath + "\\" + DateTime.Now.ToFileTime() + ".json";
                dataFile.FileName = filepath;
                dataFile.InsertRecords((IEnumerable<Record>)parameter);
            }
        }
    }
}
