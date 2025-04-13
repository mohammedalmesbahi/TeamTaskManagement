using Microsoft.EntityFrameworkCore;
using TeamTaskManagement.Domain.Common.Enums;
using TeamTaskManagement.Domain.Entities;
using TeamTaskManagement.Domain.Interfaces;
using TeamTaskManagement.Infrastructure.Data;
using TeamTaskManagement.Infrastructure.Repositories.Base;

namespace TeamTaskManagement.Infrastructure.Repositories
{
    public class TaskItemRepository : Repository<TaskItem>, ITaskItemRepository
    {
        private readonly TeamTaskDbContext _dbContext;
        public TaskItemRepository(TeamTaskDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TaskItem>> GetTasksStatusReportAsync(DateTime? startDate, DateTime? endDate, long? teamId, TaskProgressStatus? status)
        {
            var query = _dbContext.TaskItems.AsQueryable();

            if (teamId.HasValue)
            {
                query = query.Where(t => t.TeamId == teamId.Value);
            }

            if (startDate.HasValue)
            {
                query = query.Where(t => t.CreatedAt >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(t => t.CreatedAt <= endDate.Value);
            }

            if (status.HasValue)
            {
                query = query.Where(t => t.Status == status.Value);
            }

            return await query.ToListAsync();
        }

     
    }
}
