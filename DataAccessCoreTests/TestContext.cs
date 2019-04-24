using Microsoft.EntityFrameworkCore;

namespace DataAccessCoreTests
{
    public class TestContext : DbContext
    {
        #region Constructors

        public TestContext()
        {
        }

        #endregion Constructors

        #region Properties

        public DbSet<TestEntities.TestEntity> TestEntities { get; set; }
        public DbSet<TestEntities.TestEntity2> TestEntity2s { get; set; }

        #endregion Properties

        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("server=192.168.1.22;user id=qausr;Pwd=qausr;persistsecurityinfo=True;database=qa;port=3306;SslMode=none");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion Methods
    }
}