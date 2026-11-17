using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLib
{
    public static class RecordDTOHelper
    {
        public static Record DTOtoClass(RecordDTO DTO)
        {
            return new Record
            {
                Id = DTO.Id,
                Artist = DTO.Artist,
                Title = DTO.Title,
                Duration = DTO.Duration,
                PublicationYear = DTO.PublicationYear
            };
        }
    }
}
