using DataAccessCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessCoreTests
{
    public class TestData : DataServiceBase<TestContext>
    {
        public TestData(IDesignTimeDbContextFactory<TestContext> contextFactory) : base(contextFactory)
        {
        }
    }
}
