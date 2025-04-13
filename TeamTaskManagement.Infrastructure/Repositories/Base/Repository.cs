using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Domain.Common;
using TeamTaskManagement.Domain.Interfaces;
using TeamTaskManagement.Infrastructure.Data;

namespace TeamTaskManagement.Infrastructure.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TeamTaskDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(TeamTaskDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            var res = await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return res.Entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var res = _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return res.Entity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with ID {id} not found.");

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}
