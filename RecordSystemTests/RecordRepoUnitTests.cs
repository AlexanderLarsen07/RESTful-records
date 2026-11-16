using RecordLib;
namespace RecordSystemTests
{
    [TestClass]
    public sealed class RecordRepoUnitTests
    {
        private IRecordRepository _recordRepository;

        [TestInitialize]
        public void Setup()
        {
            _recordRepository = new RecordRepositoryList();
        }
        
        [TestMethod]
        public void GetAllReturnsAllRecords()
        {
            // Arrange
            int expectedCount = 3;

            // Act
            int actualCount = _recordRepository.GetAll().Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);

        }
        [TestMethod]
        public void GetAllWithParamsReturnsRecords()
        {
            //arrange

            int expected = 1;
            //act
            int actual = _recordRepository.GetAll(title:"record 1").Count;

            //assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllWithParamsNoMatching()
        {
            //act and assert

            Assert.IsEmpty(_recordRepository.GetAll(title:"record 4"));
        }

        [TestMethod]
        public void AddRecordToListsuccess()
        {
            // arrange
            Record record = new Record { Artist = "art", Title = "titel", Duration = 200, PublicationYear = 1999 };
            int expected = _recordRepository.GetAll().Count + 1;
            // act
            _recordRepository.Add(record);
            int actual = _recordRepository.GetAll().Count;
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddRecordIdIncrements()
        {
            // arrange
            Record record = new Record { Artist = "art", Title = "titel", Duration = 200, PublicationYear = 1999 };
            Record record2 = new Record { Artist = "art", Title = "title", Duration = 200, PublicationYear = 1999 };
            // act
            int id1 = _recordRepository.Add(record).Id;
            int id2 = _recordRepository.Add(record2).Id;
            // assert
            Assert.AreEqual(id1 + 1, id2);
        }

        [TestMethod]
        public void DeleteRemovesRecordFromListSuccessfully()
        {
            // arrange
            int initalCount = _recordRepository.GetAll().Count;
            // act
            _recordRepository.Delete(1);
            int actualCount = _recordRepository.GetAll().Count;
            // assert
            Assert.AreEqual(initalCount - 1, actualCount);
        }

        [TestMethod]
        public void DeleteIncorrectIdDoesnt()
        {
            // arrange
            int initalCount = _recordRepository.GetAll().Count;
            // act
            _recordRepository.Delete(27000);
            int actualCount = _recordRepository.GetAll().Count;
            // assert
            Assert.AreEqual(initalCount, actualCount);
        }
    }
}
