using RecordLib;
namespace RecordSystemTests
{
    [TestClass]
    public sealed class RecordRepoUnitTests
    {
        List<Record> testData = new List<Record>
        {
            new Record {Id = 1, Title = "Record 1", Artist = "Nikky Minaj", Duration = 727, PublicationYear = 2026 },
            new Record {Id = 2, Title = "Record 2", Artist = "Gooner Minaj", Duration = 625, PublicationYear = 2025 },
            new Record {Id = 3, Title = "Record 3", Artist = "Edger Minaj", Duration = 896, PublicationYear = 2014 }
        };

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
