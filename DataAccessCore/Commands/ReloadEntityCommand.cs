using Microsoft.EntityFrameworkCore;

namespace DataAccessCore.Commands
{
    /// <summary>
    /// Command object that reloads all values for a given Entry
    /// </summary>
    public class ReloadEntityCommand<T> : Command<T> where T : DbContext
    {
        #region Fields

        private object _entity;

        #endregion Fields

        #region Constructors

        public ReloadEntityCommand(object entity)
        {
            _entity = entity;
        }

        #endregion Constructors

        #region Methods

        public override void Execute(T context)
        {
            context.Attach(_entity);
            context.Entry(_entity).Reload();
            context.Dispose();
        }

        #endregion Methods
    }
}