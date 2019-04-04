using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessCoreTests
{
    public class TestContext : DbContext
    {
        public DbSet<TestEntities.TestEntity> TestEntities { get; set; }
        public DbSet<TestEntities.TestEntity2> TestEntity2s { get; set; }

        public TestContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("server=192.168.1.22;user id=qausr;Pwd=qausr;persistsecurityinfo=True;database=qa;port=3306;SslMode=none");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
