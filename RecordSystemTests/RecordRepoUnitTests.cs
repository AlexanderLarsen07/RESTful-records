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
    }
}
