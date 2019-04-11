using Microsoft.EntityFrameworkCore;

namespace DataAccessCore.Commands
{
    public class UpdateEntityCommand<T> : Command<T> where T : DbContext
    {
        #region Fields

        private object _entity;

        #endregion Fields

        #region Constructors

        public UpdateEntityCommand(object entity)
        {
            _entity = entity;
        }

        #endregion Constructors

        #region Methods

        public override void Execute(T context)
        {
            context.Update(_entity);
            context.SaveChanges();
            context.Dispose();
        }

        #endregion Methods
    }
}