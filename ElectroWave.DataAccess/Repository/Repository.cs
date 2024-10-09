using ElectroWave.DataAccess.Data;
using ElectroWave.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ElectroWave.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet=_context.Set<T>();   
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query = tracked ? _dbSet :  _dbSet.AsNoTracking();

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties=null)
        {
            IQueryable<T> query = _dbSet;
            if(!string.IsNullOrEmpty( includeProperties))
            {
                foreach(var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query=query.Include(property);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
    }
}
