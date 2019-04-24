using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessCoreTests
{
    public class TestContextFactory : IDesignTimeDbContextFactory<TestContext>
    {
        #region Methods

        public TestContext CreateDbContext(string[] args)
        {
            return new TestContext();
        }

        #endregion Methods
    }
}