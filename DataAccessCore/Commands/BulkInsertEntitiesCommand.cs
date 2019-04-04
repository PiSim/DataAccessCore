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
    public class BulkInsertEntitiesCommand<T> : ICommand<T> where T : DbContext
    {
        public enum InsertModes
        {
            Ignore,
            Replace
        }

        #region Fields

        private IEnumerable<object> _entities;

        #endregion Fields

        #region Constructors
        
        public BulkInsertEntitiesCommand(IEnumerable<object> entities)
        {
            _entities = entities;
        }

        #endregion Constructors

        #region Methods

        public void Execute(T context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (_entities == null)
                throw new ArgumentNullException("Entities");

            if (_entities.Count() == 0)
                return;

            Type type = _entities.GetType();

            if (InsertMode == InsertModes.Replace)
                context.UpdateRange(_entities);

            else
                context.AddRange(_entities);

            context.SaveChanges();
            context.Dispose();
        }

        #endregion Methods

        public InsertModes InsertMode { get; set; } = InsertModes.Ignore;
    }
}