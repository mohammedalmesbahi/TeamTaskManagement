using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.Common.Responses;
using TeamTaskManagement.Application.DTOs.User.Response;

namespace TeamTaskManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<UserResponseDto?>> GetByIdAsync(long id);
        Task<ServiceResponse<IEnumerable<UserResponseDto>>> GetAllAsync();
        Task<ServiceResponse<bool>> DeleteAsync(long id);
        Task<ServiceResponse<bool>> AddUserToTeamAsync(long teamId, long userId);
        Task<ServiceResponse<bool>> RemoveUserToTeamAsync(long userId);
    }
}
