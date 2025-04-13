using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers.v1;

[ApiVersion("1")]
[Route("api/v1/[controller]")]
[ApiController]

public class BaseController : ControllerBase { }
