using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RecordLib
{
    public interface IRecordRepository
    {
        Record GetById(int id);
        List<Record> GetAll();
        Record Add(Record record);
        Record Update(int id, Record record);
        Record Delete(int id);
    }
}
