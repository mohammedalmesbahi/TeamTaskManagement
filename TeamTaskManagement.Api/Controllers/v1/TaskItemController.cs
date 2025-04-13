using Api.Controllers.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamTaskManagement.Application.DTOs.TaskItem.Request;
using TeamTaskManagement.Application.Interfaces;
using TeamTaskManagement.Domain.Common.Enums;

namespace TeamTaskManagement.Api.Controllers.v1
{
    [Authorize]
    public class TaskItemController : BaseController
    {
        private readonly ITaskItemService _taskItemService;

        public TaskItemController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _taskItemService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _taskItemService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItemCreateDto dto)
        {
            var result = await _taskItemService.InsertAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TaskItemUpdateDto dto)
        {
            var result = await _taskItemService.UpdateAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _taskItemService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("GetTasksStatusReport")]
        public async Task<IActionResult> GetTasksStatusReport(DateTime? startDate, DateTime? endDate, long? teamId, TaskProgressStatus? Status)
        {
            var res =await _taskItemService.GetTasksStatusReportAsync(startDate, endDate, teamId, Status);
            return Ok(res);
        }


    }
}
