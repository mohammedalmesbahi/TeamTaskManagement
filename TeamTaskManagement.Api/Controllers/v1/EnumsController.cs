using Api.Controllers.v1;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamTaskManagement.Application.Common.Enum;
using TeamTaskManagement.Application.Interfaces;

namespace TeamTaskManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class EnumsController : BaseController
    {
        private readonly IEnumService _iEnumService;
        public EnumsController(IEnumService iEnumService)
        {
            _iEnumService = iEnumService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(EnumTypes EnumTypeId)
        {
            var result = await _iEnumService.GetEnumValuesList(EnumTypeId);
            return Ok(result);
        }
    }
}
