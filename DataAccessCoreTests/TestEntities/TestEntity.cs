
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessCoreTests.TestEntities
{
    public class TestEntity 
    {

        public int ID { get; set; }
        public string ParA { get; set; }
        public string ParB { get; set; }
        public int? TestEntity2ID { get; set; }

        public TestEntity2 TestEntity2 { get; set; }

        public object PrimaryKey => ID;
    }
}
