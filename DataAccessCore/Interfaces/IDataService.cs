using DataAccessCore.Commands;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessCore
{
    public interface IDataService<T2> where T2 : DbContext
    {
        #region Methods

        void Execute(Command<T2> commandObject);

        void Execute(BatchCommand<T2> commandObject);

        Task ExecuteAsync(Command<T2> commandObject);

        Task ExecuteAsync(BatchCommand<T2> commandObject);

        T RunQuery<T>(Scalar<T, T2> queryObject);

        IQueryable<T> RunQuery<T>(Query<T, T2> queryObject) where T : class;

        Task<T> RunQueryAsync<T>(Scalar<T, T2> queryObject);

        Task<IQueryable<T>> RunQueryAsync<T>(Query<T, T2> queryObject) where T : class;

        #endregion Methods
    }
}