using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Interfaces
{
	public interface IGenericRepository<TEntity> where TEntity : class
    {
	    
        /// <summary>
        /// Get element by id
        /// </summary>
        /// <param name="id">Product/user id</param>
        /// <returns>T entity</returns>
        ValueTask<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Get all queries
        /// </summary>
        /// <returns>IQueryable queries</returns>
       Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Find queries by predicate (where logic)
        /// </summary>
        /// <param name="predicate">Search predicate (LINQ)</param>
        /// <returns>IEnumerable lists</returns>
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        Task AddAsync(TEntity entity);

        ///<summary>
        /// Add range of entities
        /// </summary>
        /// <param name="entities">Entities objects</param>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Remove entity from database
        /// </summary>
        /// <param name="entity">Entity object</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Delete range of entities
        /// </summary>
        /// <param name="entities">Entities objects</param>
        void RemoveRange(IEnumerable<TEntity> entities);

        Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken=default);

    }
}
