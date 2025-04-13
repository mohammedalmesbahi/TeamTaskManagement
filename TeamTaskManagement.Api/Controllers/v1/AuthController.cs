using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamTaskManagement.Application.DTOs.Auth.Request;
using TeamTaskManagement.Application.Interfaces;

namespace TeamTaskManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequestDto dto)
        {
            var result = await _authService.SignInAsync(dto);
            return Ok(result);
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto dto)
        {
            var result = await _authService.SignUpAsync(dto);
            return Ok(result);
        }
    }
}
