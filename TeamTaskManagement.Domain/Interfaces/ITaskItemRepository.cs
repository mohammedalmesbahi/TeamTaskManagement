using TeamTaskManagement.Domain.Common.Enums;
using TeamTaskManagement.Domain.Entities;

namespace TeamTaskManagement.Domain.Interfaces
{
    public interface ITaskItemRepository : IRepository<TaskItem>
    {
         Task<IEnumerable<TaskItem>> GetTasksStatusReportAsync(DateTime? startDate, DateTime? endDate, long? teamId, TaskProgressStatus? Status);
    }
}
