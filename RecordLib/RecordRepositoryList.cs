using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLib
{
    public class RecordRepositoryList : IRecordRepository
    {
        private List<Record> _records;

        private static int _nextId = 4;

        public RecordRepositoryList()
        {
            _records = new List<Record>
            {
                new Record {Id = 1, Title = "Record 1", Artist = "Nikky Minaj", Duration = 727, PublicationYear = 2026 },
                new Record {Id = 2, Title = "Record 2", Artist = "Gooner Minaj", Duration = 625, PublicationYear = 2025 },
                new Record {Id = 3, Title = "Record 3", Artist = "Edger Minaj", Duration = 896, PublicationYear = 2014 }
            };
        }

        public Record Add(Record record)
        {
            throw new NotImplementedException();
        }

        public Record? Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Record> GetAll()
        {
            return new List<Record>(_records);
        }

        public Record? GetById(int id)
        {
            return _records.Find(r => r.Id == id);
        }

        public Record? Update(int id, Record record)
        {
            throw new NotImplementedException();
        }
    }
}
