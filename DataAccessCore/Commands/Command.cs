using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessCore.Commands
{
    public abstract class Command<T> where T:DbContext
    {
        public abstract void Execute(T context);

        public virtual Task ExecuteAsync(T context)
        {
            return Task.Run(() => Execute(context));
        }
    }
}
