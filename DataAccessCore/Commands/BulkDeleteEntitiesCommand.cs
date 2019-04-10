using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccessCore.Commands
{
    /// <summary>
    /// Command object that deletes multiple entries in a single transaction
    /// </summary>
    /// <typeparam name="T">The type of DbContext to target</typeparam>
    public class BulkDeleteEntitiesCommand<T> : BulkCommand<T> where T : DbContext
    {
        #region Constructors

        public BulkDeleteEntitiesCommand(IEnumerable<object> entities, int batchSize = 10000) : base(entities, batchSize)
        {
        }

        #endregion Constructors

        #region Methods

        protected override void ExecuteBatch(IEnumerable<object> batch, T context)
        {
            context.RemoveRange(batch);
            context.SaveChanges();
        }

        #endregion Methods
    }
}