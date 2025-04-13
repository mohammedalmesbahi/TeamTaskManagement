using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Domain.Entities;
using TeamTaskManagement.Domain.Interfaces;
using TeamTaskManagement.Infrastructure.Data;

namespace TeamTaskManagement.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TeamTaskDbContext _dbContext;
        private readonly DbSet<Role> _dbSet;

        public RoleRepository(TeamTaskDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Role>();
        }

        public async Task<Role?> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<Role?> GetByNameAsync(string roleName)
        {
            return await _dbSet.FirstOrDefaultAsync(r => r.Name.ToLower() == roleName.ToLower());
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Role> CreateAsync(Role role)
        {
            var entry = await _dbSet.AddAsync(role);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            var entry = _dbSet.Update(role);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var role = await GetByIdAsync(id);
            if (role == null)
                return false;
            _dbSet.Remove(role);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
