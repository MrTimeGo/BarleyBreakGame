using BarleyBreakGameInterface.Dao;
using BarleyBreakGameInterface.Model;
using BarleyBreakGameInterface.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BarleyBreakGameInterface.ViewModel
{
    public class RecordsViewModel
    {
        public ICommand ExportXml { get; set; } = new ExportXmlCommand(new XmlDataFile());

        public ICommand ExportJson { get; set; } = new ExportJsonCommand(new JsonDataFile());

        public ObservableCollection<Record> RecordsCollection { get; }

        public RecordsViewModel()
        {
            var datafile = new JsonDataFile("datafile.json");
            var records = datafile.GetRecords();
            RecordsCollection = new ObservableCollection<Record>(records.OrderBy(r => r.StepsConter));
        }
    }
}
