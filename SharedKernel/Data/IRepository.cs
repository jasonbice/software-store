using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace SharedKernel.Data
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets all <typeparamref name="T"/> entities from the data store.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>All <typeparamref name="T"/> entities from the data store.</returns>
        public Task<IQueryable<T>> AllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Gets all <typeparamref name="T"/> entities that match the <paramref name="filterExpression"/>.
        /// </summary>
        /// <param name="filterExpression"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IQueryable<T>> FilterAsync(
            Expression<Func<T, bool>> filterExpression,
            CancellationToken cancellationToken);
    }
}