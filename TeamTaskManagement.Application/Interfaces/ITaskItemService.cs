using TeamTaskManagement.Application.Common.Responses;
using TeamTaskManagement.Application.DTOs.TaskItem.Request;
using TeamTaskManagement.Application.DTOs.TaskItem.Response;
using TeamTaskManagement.Application.Interfaces.Base;
using TeamTaskManagement.Domain.Common.Enums;
using TeamTaskManagement.Domain.Entities;

namespace TeamTaskManagement.Application.Interfaces
{
    public interface ITaskItemService : IBaseService<TaskItem, TaskItemCreateDto, TaskItemUpdateDto, TaskItemResponseDto>
    {
        public Task<ServiceResponse<IEnumerable<TaskItemResponseDto>>> GetTasksStatusReportAsync(DateTime? startDate, DateTime? endDate, long? teamId, TaskProgressStatus? Status);
    }

}
