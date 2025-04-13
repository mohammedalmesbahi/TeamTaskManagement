using AutoMapper;
using TeamTaskManagement.Application.DTOs.Team.Request;
using TeamTaskManagement.Application.DTOs.Team.Response;
using TeamTaskManagement.Application.Interfaces;
using TeamTaskManagement.Application.Services.Base;
using TeamTaskManagement.Domain.Entities;
using TeamTaskManagement.Domain.Interfaces;

namespace TeamTaskManagement.Application.Services
{
    public class TeamService : BaseService<Team, TeamCreateDto, TeamUpdateDto, TeamResponseDto>, ITeamService
    {
        public TeamService(ITeamRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

       

        protected override Task ValidationInsertRequest(TeamCreateDto dto)
        {
            return Task.CompletedTask;
        }

        protected override Task ValidationUpdateRequest(TeamUpdateDto dto)
        {
            return Task.CompletedTask;
        }
    }
}
