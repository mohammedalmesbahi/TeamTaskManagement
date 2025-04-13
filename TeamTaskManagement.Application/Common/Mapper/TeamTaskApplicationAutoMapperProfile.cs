using AutoMapper;
using TeamTaskManagement.Application.DTOs.Role.Request;
using TeamTaskManagement.Application.DTOs.Role.Response;
using TeamTaskManagement.Application.DTOs.TaskItem.Request;
using TeamTaskManagement.Application.DTOs.TaskItem.Response;
using TeamTaskManagement.Application.DTOs.Team.Request;
using TeamTaskManagement.Application.DTOs.Team.Response;
using TeamTaskManagement.Application.DTOs.User.Response;
using TeamTaskManagement.Domain.Entities;

namespace TeamTaskManagement.Application.Common.Mapper
{
    public class TeamTaskApplicationAutoMapperProfile : Profile
    {
        public TeamTaskApplicationAutoMapperProfile ()
        {
            #region User
            CreateMap<User, UserResponseDto>().ReverseMap();
            #endregion

            #region Role
            CreateMap<Role, RoleResponseDto>().ReverseMap();
            CreateMap<RoleCreateDto, Role>();
            CreateMap<RoleUpdateDto, Role>();
            #endregion

            #region TaskItem
            CreateMap<TaskItem, TaskItemResponseDto>().ReverseMap();
            CreateMap<TaskItemCreateDto, TaskItem>();
            CreateMap<TaskItemUpdateDto, TaskItem>();
            #endregion

            #region Team
            CreateMap<Team, TeamResponseDto>().ReverseMap();
            CreateMap<TeamCreateDto, Team>();
            CreateMap<TeamUpdateDto, Team>();
            #endregion

        }
    }
}
