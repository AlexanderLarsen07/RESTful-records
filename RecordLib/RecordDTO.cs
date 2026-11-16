using System;
using System.Collections.Generic;
using System.Text;

namespace RecordLib
{
    public record RecordDTO(
        int id,
        string title,
        string artist,
        int duration,
        int publicationYear
        )
    {
    }
}
