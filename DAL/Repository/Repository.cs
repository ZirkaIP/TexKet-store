using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
	public class Repository<T> : IGenericRepository<T> where T: class
	{
		protected readonly DbContext Context;

		public Repository(DbContext context)
		{
			Context = context;
		}

		public T Get(int id)
		{
			return Context.Set<T>().Find(id);
		}

		public IEnumerable<T> GetAll()
		{
			return Context.Set<T>().ToList();
		}

		public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
		{
			return Context.Set<T>().Where(predicate);
		}

		public void Add(T entity)
		{
			Context.Set<T>().Add(entity);
		}

		public void AddRange(IEnumerable<T> entities)
		{
			Context.Set<T>().AddRange(entities);
		}

		public void Delete(T entity)
		{
			Context.Set<T>().Remove(entity);
		}

		public void DeleteRange(IEnumerable<T> entities)
		{
			Context.Set<T>().RemoveRange(entities);
		}
	}
}
