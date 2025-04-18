using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Domain.Common.Enums;
using TeamTaskManagement.Domain.Entities;
using TeamTaskManagement.Domain.Interfaces;
using TeamTaskManagement.Infrastructure.Data;
using TeamTaskManagement.Infrastructure.Repositories.Base;

namespace TeamTaskManagement.Infrastructure.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        private readonly TeamTaskDbContext _dbContext;
        public TeamRepository(TeamTaskDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public override async Task<IEnumerable<Team>> FindAllAsync(Expression<Func<Team, bool>> predicate)
        {
            return await _dbContext.Teams
                .Where(predicate)
                .Include(t => t.Users)
                    .ThenInclude(u => u.TaskItems)
                .Include(t => t.Tasks)
                .AsNoTracking()
                .ToListAsync();
        }



    }
}
