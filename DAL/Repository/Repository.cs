using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
	public class Repository<TEntity> : IGenericRepository<TEntity> where TEntity: class
	{
		protected readonly DbContext Context;

		public Repository(DbContext context)
		{
			Context = context;
		}

		public async Task AddAsync(TEntity entity)
		{
			await Context.Set<TEntity>().AddAsync(entity);
			await Context.SaveChangesAsync();
		}

		public async Task AddRangeAsync(IEnumerable<TEntity> entities)
		{
			await Context.Set<TEntity>().AddRangeAsync(entities);
			await Context.SaveChangesAsync();
		}

		public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
		{
			return Context.Set<TEntity>().AsNoTracking().Where(predicate);
		}

		public async  Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await Context.Set<TEntity>().ToListAsync();
		}

		public  ValueTask<TEntity> GetByIdAsync(Guid id)
		{
			return Context.Set<TEntity>().FindAsync(id);
		}

		public void Remove(TEntity entity)
		{
			Context.Set<TEntity>().Remove(entity);
			Context.SaveChanges();
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			Context.Set<TEntity>().RemoveRange(entities);
			Context.SaveChanges();
		}

		public async Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
		{
			foreach (var entity in entities)
			{
				 Context.Entry(entity).State = EntityState.Modified;
			}

			await Context.SaveChangesAsync(cancellationToken);
		}
	}
}
