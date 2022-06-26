using BarleyBreakGameInterface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.IO;

namespace BarleyBreakGameInterface.Dao
{
    internal class XmlDataFile : DataFileTemplate
    {
        public XmlDataFile(string fileName) : base(fileName)
        {
        }

        public XmlDataFile() { }

        protected override IEnumerable<Record> DeserializeRecords(string serializedData)
        {
            var xmlSerializer = new XmlSerializer(typeof(Record[]));
            using (StringReader reader = new StringReader(serializedData))
            {
                return (IEnumerable<Record>)xmlSerializer.Deserialize(reader);
            }
        }

        protected override string SerializeRecords(IEnumerable<Record> records)
        {
            var xmlSerializer = new XmlSerializer(typeof(Record[]));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, records.ToArray());
                return textWriter.ToString();
            }
        }
    }
}
