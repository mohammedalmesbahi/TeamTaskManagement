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
    public class UserRepository : IUserRepository
    {
        private readonly TeamTaskDbContext _dbContext;
        private readonly DbSet<User> _dbSet;

        public UserRepository(TeamTaskDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<User>();
        }

        public async Task<User?> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserName.ToLower() == username.ToLower());
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }


        public async Task<bool> DeleteAsync(long id)
        {
            var user = await GetByIdAsync(id);
            if (user == null)
                return false;

            _dbSet.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddUserToTeamAsync(long teamId, long userId)
        {
            var team = await _dbContext.Teams.FirstOrDefaultAsync(t => t.Id == teamId);
            var user = await _dbSet.FindAsync(userId);

            if (team == null || user == null)
                return false;
            user.TeamId = teamId;
            user.Team = team;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemoveUserToTeamAsync( long userId)
        {
       
            var user = await _dbSet.FindAsync(userId);

            if (user == null)
                return false;
            user.TeamId = null;
            user.Team = null;
            await _dbContext.SaveChangesAsync();
            return true;
        }
      
    }
}
