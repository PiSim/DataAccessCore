using DataAccessCore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCoreTests;
using DataAccessCoreTests.TestEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestContext = DataAccessCoreTests.TestContext;

namespace DataAccessCore.Commands.Tests
{
    [TestClass()]
    public class BulkInsertEntitiesCommandTests
    {
        TestData testData = new TestData(new TestContextFactory());

        [TestMethod()]
        public void ExecuteTest()
        {
            IList<TestEntity> entities = new List<TestEntity>();

            for (int a = 0; a < 10; a++)
                entities.Add(new TestEntity() { ParA = "a", ParB = "A" });

            Assert.IsNotNull(entities);


            BulkInsertEntitiesCommand<TestContext> testCommand = new BulkInsertEntitiesCommand<TestContext>(entities);
            testCommand.InsertMode = BulkInsertEntitiesCommand<TestContext>.InsertModes.Replace;

            Assert.IsNotNull(testCommand);
            Assert.IsNotNull(testCommand.InsertMode);

            testData.Execute(testCommand);
            
        }
    }
}