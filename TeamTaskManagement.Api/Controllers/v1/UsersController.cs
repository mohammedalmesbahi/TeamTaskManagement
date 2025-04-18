using Api.Controllers.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamTaskManagement.Application.Interfaces;
using TeamTaskManagement.Application.Services;

namespace TeamTaskManagement.Api.Controllers.v1
{
    [Authorize(Policy= "Admin")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _userService.DeleteAsync(id);
            return Ok(result);
        }

        [HttpPost("addUserToTeam")]
        public async Task<IActionResult> AddUserToTeam(long teamId, long userId)
        {
            var result = await _userService.AddUserToTeamAsync(teamId, userId);
            return Ok(result);
        }
        [HttpPost("removeUserToTeam")]
        public async Task<IActionResult> RemoveUserToTeam(long userId)
        {
            var result = await _userService.RemoveUserToTeamAsync(userId);
            return Ok(result);
        }
    }
}
