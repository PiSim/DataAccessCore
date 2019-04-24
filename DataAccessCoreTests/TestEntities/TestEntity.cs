namespace DataAccessCoreTests.TestEntities
{
    public class TestEntity
    {
        #region Properties

        public int ID { get; set; }
        public string ParA { get; set; }
        public string ParB { get; set; }
        public object PrimaryKey => ID;
        public TestEntity2 TestEntity2 { get; set; }
        public int? TestEntity2ID { get; set; }

        #endregion Properties
    }
}