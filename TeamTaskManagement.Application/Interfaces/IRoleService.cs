using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.DTOs.Role.Request;
using TeamTaskManagement.Application.DTOs.Role.Response;
using TeamTaskManagement.Application.Interfaces.Base;
using TeamTaskManagement.Domain.Entities;

namespace TeamTaskManagement.Application.Interfaces
{
    public interface IRoleService
    {
        Task<RoleResponseDto> CreateAsync(RoleCreateDto dto);
        Task<RoleResponseDto> UpdateAsync(RoleUpdateDto dto);
        Task<RoleResponseDto?> GetByIdAsync(long id);
        Task<IEnumerable<RoleResponseDto>> GetAllAsync();
        Task<bool> DeleteAsync(long id);
    }
}
