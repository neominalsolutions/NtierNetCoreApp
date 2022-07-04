using DatabaseScaffoldApplication.Domain.Models;
using DatabaseScaffoldApplication.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Infrastructure.Repositories
{
    public abstract class EFCoreRepository<T> : IRepository<T> where T:class
    {

        protected NORTHWNDContext _dbContext;
        private DbSet<T> _dbSet;

        public EFCoreRepository(NORTHWNDContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual void Create(T item)
        {
            _dbSet.Add(item);
        }

        public async virtual Task CreateAsync(T item)
        {
            await _dbContext.AddAsync(item);
        }

        public virtual void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }


        public virtual int Save()
        {
            return _dbContext.SaveChanges();
        }

        public async virtual Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public virtual T Select(int id)
        {
            return _dbSet.Find(id);
        }

        public async virtual Task<T> SelectAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async virtual Task<List<T>> SelectManayAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual List<T> SelectMany()
        {
            return _dbSet.ToList();
        }

        public virtual void Update(T item)
        {
            _dbContext.Update(item);
        }

       
    }
}
