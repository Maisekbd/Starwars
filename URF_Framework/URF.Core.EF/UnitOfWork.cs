using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using URF.Core.Abstractions;

namespace URF.Core.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext Context { get; }
        private IDbContextTransaction _transaction;
        public UnitOfWork(DbContext context)
        {
            Context = context;
         
        }



        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await Context.SaveChangesAsync(cancellationToken);

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default)
            => await Context.Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);

        public void BeginTransaction() => _transaction = Context.Database.BeginTransaction();

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await Context.SaveChangesAsync(cancellationToken);
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}