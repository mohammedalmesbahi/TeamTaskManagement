using TeamTaskManagement.Application.DTOs.Team.Request;
using TeamTaskManagement.Application.DTOs.Team.Response;
using TeamTaskManagement.Application.Interfaces.Base;
using TeamTaskManagement.Domain.Entities;

namespace TeamTaskManagement.Application.Interfaces
{
    public interface ITeamService : IBaseService<Team, TeamCreateDto, TeamUpdateDto, TeamResponseDto>
    {
    }

}
