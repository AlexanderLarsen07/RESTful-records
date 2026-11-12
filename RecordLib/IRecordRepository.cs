using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RecordLib
{
    public interface IRecordRepository
    {
        Record? GetById(int id);
        List<Record> GetAll();
        List<Record> GetAll(int? id = null, string? title = null, string? artist = null, int? minDuration = null, int? maxDuration = null, int? minPubYear = null, int? maxPubYear = null);
        Record Add(Record record);
        Record? Update(int id, Record record);
        Record? Delete(int id);
    }
}
