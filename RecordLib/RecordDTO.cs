using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLib
{
    public record RecordDTO(
        int Id,
        string Title,
        string Artist,
        int Duration,
        int PublicationYear
        )
    {
    }
}
