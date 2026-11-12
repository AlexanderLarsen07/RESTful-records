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
            int actual = _recordRepository.GetAll("record 1").Count;

            //assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllWithParamsNoMatching()
        {
            //act and assert

            Assert.IsEmpty(_recordRepository.GetAll("record 4"));
        }
    }
}
