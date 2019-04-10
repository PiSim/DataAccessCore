using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DataAccessCore.Commands
{
    /// <summary>
    /// Command Object that inserts a set of entities in a single transaction
    /// </summary>
    public class BulkInsertEntitiesCommand<T> : BulkCommand<T> where T : DbContext
    {
        #region Constructors
        
        public BulkInsertEntitiesCommand(IEnumerable<object> entities, int batchSize = 10000) : base(entities, batchSize)
        {
        }

        #endregion Constructors

        #region Methods
        
        protected override void ExecuteBatch(IEnumerable<object> batch, T context)
        {
            context.AddRange(batch);
            context.SaveChanges();
        }

        #endregion Methods
    }
}