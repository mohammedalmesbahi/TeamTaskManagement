using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Domain.Entities;
using TeamTaskManagement.Domain.Interfaces;
using TeamTaskManagement.Infrastructure.Data;
using TeamTaskManagement.Infrastructure.Repositories.Base;

namespace TeamTaskManagement.Infrastructure.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(TeamTaskDbContext dbContext) : base(dbContext)
        {
        }
    }
}
