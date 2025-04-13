using Api.Controllers.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamTaskManagement.Application.DTOs.Team.Request;
using TeamTaskManagement.Application.Interfaces;

namespace TeamTaskManagement.Api.Controllers.v1
{
    [Authorize(Policy = "Admin")]
    public class TeamController : BaseController
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _teamService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _teamService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamCreateDto dto)
        {
            var result = await _teamService.InsertAsync(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TeamUpdateDto dto)
        {
            var result = await _teamService.UpdateAsync(dto);
            return Ok(result);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _teamService.DeleteAsync(id);
            return Ok(result);
        }
       
       
    }
}
