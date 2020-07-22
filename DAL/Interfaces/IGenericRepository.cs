using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IGenericRepository<T> where T : class
    {
	    
        /// <summary>
        /// Get element by id
        /// </summary>
        /// <param name="id">Product/user id</param>
        /// <returns>T entity</returns>
        T Get(int id);

        /// <summary>
        /// Get all queries
        /// </summary>
        /// <returns>IQueryable queries</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Find queries by predicate (where logic)
        /// </summary>
        /// <param name="predicate">Search predicate (LINQ)</param>
        /// <returns>IEnumerable lists</returns>
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        void Add(T entity);

        ///<summary>
        /// Add range of entities
        /// </summary>
        /// <param name="entities">Entities objects</param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Remove entity from database
        /// </summary>
        /// <param name="entity">Entity object</param>
        void Delete(T entity);

        /// <summary>
        /// Delete range of entities
        /// </summary>
        /// <param name="entities">Entities objects</param>
        void DeleteRange(IEnumerable<T> entities);

    }
}
