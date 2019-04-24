using DataAccessCoreTests;
using DataAccessCoreTests.TestEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using TestContext = DataAccessCoreTests.TestContext;

namespace DataAccessCore.Commands.Tests
{
    [TestClass()]
    public class BatchInsertEntitiesCommandTests
    {
        private bool sharedFlag;

        #region Fields

        private TestData testData = new TestData(new TestContextFactory());

        #endregion Fields

        #region Methods

        [TestMethod()]
        public void ExecuteAsyncTest()
        {
            testData.Execute(new DeleteAllEntitiesCommand<TestContext, TestEntity>());

            IList<TestEntity> entities = new List<TestEntity>();

            for (int a = 0; a < 100000; a++)
                entities.Add(new TestEntity() { ParA = "a", ParB = "A" });

            Assert.IsNotNull(entities);

            BatchInsertEntitiesCommand<TestContext> testCommand = new BatchInsertEntitiesCommand<TestContext>(entities);

            Assert.IsNotNull(testCommand);

            Task.Run(() => testData.ExecuteAsync(testCommand))
                .Wait();

            return;
            
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            testData.Execute(new DeleteAllEntitiesCommand<TestContext, TestEntity>());

            IList<TestEntity> entities = new List<TestEntity>();

            for (int a = 0; a < 100000; a++)
                entities.Add(new TestEntity() { ParA = "a", ParB = "A" });

            Assert.IsNotNull(entities);

            BatchInsertEntitiesCommand<TestContext> testCommand = new BatchInsertEntitiesCommand<TestContext>(entities);

            Assert.IsNotNull(testCommand);

            testData.Execute(testCommand);
        }

        [TestMethod()]
        public void ProgressUpdatedEventTest()
        {
            testData.Execute(new DeleteAllEntitiesCommand<TestContext, TestEntity>());

            IList<TestEntity> entities = new List<TestEntity>();

            for (int a = 0; a < 100000; a++)
                entities.Add(new TestEntity() { ParA = "a", ParB = "A" });

            Assert.IsNotNull(entities);

            BatchInsertEntitiesCommand<TestContext> testCommand = new BatchInsertEntitiesCommand<TestContext>(entities);

            Assert.IsNotNull(testCommand);
            sharedFlag = false;
            testCommand.ProgressChanged += OnProgressChanged; 


            testData.Execute(testCommand);
            Assert.IsTrue(sharedFlag);
        }

        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            sharedFlag = true;
        }
        #endregion Methods
    }
}