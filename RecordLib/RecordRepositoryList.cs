using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLib
{
    public class RecordRepositoryList : IRecordRepository
    {
        private List<Record> _records;

        private static int _nextId = 1;

        public RecordRepositoryList()
        {
            _records = new List<Record>();
        }

        public Record Add(Record record)
        {
            throw new NotImplementedException();
        }

        public Record Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Record> GetAll()
        {
            return new List<Record>(_records);
        }

        public Record GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Record Update(int id, Record record)
        {
            throw new NotImplementedException();
        }
    }
}
