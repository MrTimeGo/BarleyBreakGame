using BarleyBreakGameInterface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BarleyBreakGameInterface.Dao
{
    public class JsonDataFile : DataFileTemplate
    {
        public JsonDataFile(string fileName) : base(fileName)
        {
        }

        public JsonDataFile() { }

        protected override IEnumerable<Record> DeserializeRecords(string serializedData)
        {
            return (IEnumerable<Record>)JsonSerializer.Deserialize(serializedData, typeof(IEnumerable<Record>));
        }

        protected override string SerializeRecords(IEnumerable<Record> records)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,

            };
            return JsonSerializer.Serialize<IEnumerable<Record>>(records, options);
        }
    }
}
