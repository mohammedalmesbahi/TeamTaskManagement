using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.DTOs.Role.Request;
using TeamTaskManagement.Application.DTOs.Role.Response;
using TeamTaskManagement.Application.Interfaces;
using TeamTaskManagement.Domain.Entities;
using TeamTaskManagement.Domain.Interfaces;

namespace TeamTaskManagement.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleResponseDto> CreateAsync(RoleCreateDto dto)
        {
            var role = _mapper.Map<Role>(dto);
            var created = await _roleRepository.CreateAsync(role);
            return _mapper.Map<RoleResponseDto>(created);
        }

        public async Task<RoleResponseDto> UpdateAsync(RoleUpdateDto dto)
        {
            var role = _mapper.Map<Role>(dto);
            var updated = await _roleRepository.UpdateAsync(role);
            return _mapper.Map<RoleResponseDto>(updated);
        }

        public async Task<RoleResponseDto?> GetByIdAsync(long id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            return role == null ? null : _mapper.Map<RoleResponseDto>(role);
        }

        public async Task<IEnumerable<RoleResponseDto>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleResponseDto>>(roles);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _roleRepository.DeleteAsync(id);
        }
    }
}
