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
                new Record {Id = 2, Title = "Legs don't work", Artist = "Ed Sheeran", Duration = 625, PublicationYear = 2025 },
                new Record {Id = 3, Title = "Shout", Artist = "TylerOne", Duration = 896, PublicationYear = 2014 }
            };
        }

        public Record Add(Record record)
        {
            record.Id = _nextId++;
            _records.Add(record);
            return record;
        }

        public Record? Delete(int id)
        {
            Record? record = GetById(id);
            if(record == null)
            {
                return null;
            }
            _records.Remove(record);
            return record;

        }

        public List<Record> GetAll()
        {
            return new List<Record>(_records);
        }

        public List<Record> GetAll(int? id = null , 
                                   string? title = null, 
                                   string? artist = null, 
                                   int? minDuration = null, 
                                   int? maxDuration = null, 
                                   int? minPubYear = null, 
                                   int? maxPubYear = null)
        {
            List<Record> records = new List<Record>();

            foreach(Record record in _records)
            {
                int count = 0;
                if(id == null || record.Id == id)
                {
                    count++;
                }
                if(title == null || record.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
                if(artist == null || record.Artist.Contains(artist, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
                if (minDuration == null || record.Duration > minDuration)
                {
                    count++;
                }
                if (maxDuration == null || record.Duration < maxDuration)
                {
                    count++;
                }
                if (minPubYear == null || record.PublicationYear > minPubYear)
                {
                    count++;
                }
                if (maxPubYear == null || record.PublicationYear > maxPubYear)
                {
                    count++;
                }
                if (count == 7)
                    records.Add(record);
            }

            return records;
        }

        public Record? GetById(int id)
        {
            return _records.Find(r => r.Id == id);
        }

        public Record? Update(int id, Record record)
        {
            Record? recordToUpdate = GetById(id);
            if (recordToUpdate!= null)
            {
                recordToUpdate.Title = record.Title;
                recordToUpdate.Artist = record.Artist;
                recordToUpdate.Duration = record.Duration;
                recordToUpdate.PublicationYear = record.PublicationYear;
            }
            return recordToUpdate;
        }
    }
}
