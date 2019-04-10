using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccessCore.Commands
{
    /// <summary>
    /// Command Object that updates the database values of a set of entities in a single transaction
    /// </summary>
    public class BulkUpdateEntitiesCommand<T> :BulkCommand<T> where T : DbContext
    {
        #region Constructors

        public BulkUpdateEntitiesCommand(IEnumerable<object> entities, int batchSize = 10000) : base(entities, batchSize)
        {
        }

        #endregion Constructors

        #region Methods

        protected override void ExecuteBatch(IEnumerable<object> batch, T context)
        {
            context.UpdateRange(batch);
            context.SaveChanges();
        }

        #endregion Methods
    }
}