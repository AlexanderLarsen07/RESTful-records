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
                Id = DTO.id,
                Artist = DTO.artist,
                Title = DTO.title,
                Duration = DTO.duration,
                PublicationYear = DTO.publicationYear
            };
        }
    }
}
