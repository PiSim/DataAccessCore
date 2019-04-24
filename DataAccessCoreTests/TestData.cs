using DataAccessCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessCoreTests
{
    public class TestData : DataServiceBase<TestContext>
    {
        #region Constructors

        public TestData(IDesignTimeDbContextFactory<TestContext> contextFactory) : base(contextFactory)
        {
        }

        #endregion Constructors
    }
}