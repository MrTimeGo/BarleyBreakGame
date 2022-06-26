using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BarleyBreakGameInterface.Model;

namespace BarleyBreakGameInterface.Dao
{
    public abstract class DataFileTemplate
    {
        public string FileName { get; set; }

        protected DataFileTemplate(string fileName)
        {
            this.FileName = fileName;
        }

        public DataFileTemplate() { }

        public IEnumerable<Record> GetRecords()
        {
            string readedData = "";

            using (var stream = GetFileStream(FileAccess.Read))
            {
                readedData = ReadTextFromStream(stream);
            }

            return string.IsNullOrEmpty(readedData) ? new List<Record>() : DeserializeRecords(readedData);
        }

        public void InsertRecord(Record record)
        {
            InsertRecords(new[] { record });
        }

        public void InsertRecords(IEnumerable<Record> records)
        {
            string readedData = "";

            using (var stream = GetFileStream(FileAccess.Read))
            {
                readedData = ReadTextFromStream(stream);
            }

            IEnumerable<Record> oldRecords = string.IsNullOrEmpty(readedData) ? new List<Record>() : DeserializeRecords(readedData);
            IEnumerable<Record> newRecords = oldRecords.Concat(records);
            string serializedData = SerializeRecords(newRecords);

            using (var stream = GetFileStream(FileAccess.Write))
            {
                WriteTextToStream(stream, serializedData);
            }
        }

        private void WriteTextToStream(Stream stream, string text)
        {
            var writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
        }

        private string ReadTextFromStream(Stream stream)
        {
            var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        private Stream GetFileStream(FileAccess access)
        {
            return new FileStream(FileName, FileMode.OpenOrCreate, access);
        }

        protected abstract string SerializeRecords(IEnumerable<Record> records);

        protected abstract IEnumerable<Record> DeserializeRecords(string serializedData);
    }
}
