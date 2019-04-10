using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessCore.Commands
{
    /// <summary>
    /// Command object that truncates the table associated with an entity type
    /// </summary>
    /// <typeparam name="T">The entity type to truncate</typeparam>
    public class DeleteAllEntitiesCommand<T,T2> : ICommand<T> where T : DbContext where T2 : class
    {
        public DeleteAllEntitiesCommand()
        {
        }

        public void Execute(T context)
        {
            context.RemoveRange(context.Set<T2>().ToList());
            context.SaveChanges();
            context.Dispose();
        }
    }
}
