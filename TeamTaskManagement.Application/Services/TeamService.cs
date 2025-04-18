using AutoMapper;
using TeamTaskManagement.Application.Common.Responses;
using TeamTaskManagement.Application.DTOs.TaskItem.Response;
using TeamTaskManagement.Application.DTOs.Team.Request;
using TeamTaskManagement.Application.DTOs.Team.Response;
using TeamTaskManagement.Application.DTOs.User.Response;
using TeamTaskManagement.Application.Interfaces;
using TeamTaskManagement.Application.Services.Base;
using TeamTaskManagement.Domain.Common.Enums;
using TeamTaskManagement.Domain.Entities;
using TeamTaskManagement.Domain.Interfaces;

namespace TeamTaskManagement.Application.Services
{
    public class TeamService : BaseService<Team, TeamCreateDto, TeamUpdateDto, TeamResponseDto>, ITeamService
    {
        public TeamService(ITeamRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
      public override async Task<ServiceResponse<IEnumerable<TeamResponseDto>>> GetAllAsync()
        {
            try
            {
                var teams = await _repository.FindAllAsync(m => m.State ==EntityState.Active || m.State==EntityState.Inactive);
                var result = teams.Select(team => new TeamResponseDto
                {
                    Id = team.Id,
                    Name = team.Name,
                    State = team.State,
                    Description = team.Description,
                    CreatedAt=team.CreatedAt,
                    UpdatedAt=team.UpdatedAt,
                    
                    Users = team.Users?.Where(s => s.State == EntityState.Active || s.State == EntityState.Inactive).Select(user => new UserResponseDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        CreatedAt=user.CreatedAt,
                        PhoneNumber = user.PhoneNumber,
                        UpdatedAt=user.UpdatedAt,
                        State=user.State,
                        UserName=user.UserName,
                        TeamId=user.TeamId,
                        
                        TaskItems = user.TaskItems?.Select(task => new TaskItemResponseDto
                        {
                            Id = task.Id,
                            Title = task.Title,
                            Description = task.Description,
                            DueDate = task.DueDate,
                            State = task.State,
                            CreatedAt=task.CreatedAt,
                            UpdatedAt = task.UpdatedAt,
                            TeamId = task.TeamId,
                            Status = task.Status,
                            UserId = task.UserId,
                            PriorityLevel = task.PriorityLevel,
                        }).ToList() ?? new List<TaskItemResponseDto>()
                    }).ToList() ?? new List<UserResponseDto>(),
                    Tasks = team.Tasks?.Where(s => s.State == EntityState.Active || s.State == EntityState.Inactive).Select(task => new TaskItemResponseDto
                    {
                        Id = task.Id,
                        Title = task.Title,
                        Description = task.Description,
                        DueDate = task.DueDate,
                        State = task.State,
                        PriorityLevel = task.PriorityLevel,
                        CreatedAt = task.CreatedAt,
                        UpdatedAt = task.UpdatedAt,
                        UserId = task.UserId,
                        Status = task.Status,
                        TeamId = task.TeamId,
                        
                    }).ToList() ?? new List<TaskItemResponseDto>()
                });
                return ServiceResponse<IEnumerable<TeamResponseDto>>.SuccessResponse(result, "تمت العملية بنجاح");

            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<TeamResponseDto>>.FailureResponse("لم يتم جلب البيانات");
            }
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
