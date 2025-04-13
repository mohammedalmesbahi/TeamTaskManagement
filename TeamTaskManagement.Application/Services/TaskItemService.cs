using AutoMapper;
using TeamTaskManagement.Application.Common.Responses;
using TeamTaskManagement.Application.DTOs.TaskItem.Request;
using TeamTaskManagement.Application.DTOs.TaskItem.Response;
using TeamTaskManagement.Application.Interfaces;
using TeamTaskManagement.Application.Services.Base;
using TeamTaskManagement.Domain.Common.Enums;
using TeamTaskManagement.Domain.Entities;
using TeamTaskManagement.Domain.Interfaces;

namespace TeamTaskManagement.Application.Services
{
    public class TaskItemService : BaseService<TaskItem, TaskItemCreateDto, TaskItemUpdateDto, TaskItemResponseDto>, ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;

        public TaskItemService(ITaskItemRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _taskItemRepository = repository;
        }

        public async Task<ServiceResponse<IEnumerable<TaskItemResponseDto>>> GetTasksStatusReportAsync(DateTime? startDate, DateTime? endDate, long? teamId, TaskProgressStatus? Status)
        {
            try
            {
                var entities = await _taskItemRepository.GetTasksStatusReportAsync(startDate,endDate,teamId,Status);
                var dtoResult = _mapper.Map<IEnumerable<TaskItemResponseDto>>(entities);
                return ServiceResponse<IEnumerable<TaskItemResponseDto>>.SuccessResponse(dtoResult, "تمت العملية بنجاح");
            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<TaskItemResponseDto>>.FailureResponse(ex.Message);
            }
        }

        protected override Task ValidationInsertRequest(TaskItemCreateDto dto)
        {
            return Task.CompletedTask;
        }

        protected override Task ValidationUpdateRequest(TaskItemUpdateDto dto)
        {
            return Task.CompletedTask;
        }
    }
}
