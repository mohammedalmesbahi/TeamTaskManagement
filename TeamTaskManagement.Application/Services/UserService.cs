using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.Common.Responses;
using TeamTaskManagement.Application.DTOs.User.Response;
using TeamTaskManagement.Application.Interfaces;
using TeamTaskManagement.Domain.Interfaces;

namespace TeamTaskManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<UserResponseDto>> GetByIdAsync(long id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);

                if (user == null)
                {
                    return ServiceResponse<UserResponseDto>.FailureResponse("المستخدم غير موجود");
                }

                var userDto = _mapper.Map<UserResponseDto>(user);
                return ServiceResponse<UserResponseDto>.SuccessResponse(userDto, "تمت العملية بنجاح");
            }
            catch (Exception ex)
            {
                return ServiceResponse<UserResponseDto>.FailureResponse(ex.Message);
            }
        }
        public async Task<ServiceResponse<IEnumerable<UserResponseDto>>> GetAllAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                var mappedUsers = _mapper.Map<IEnumerable<UserResponseDto>>(users);

                if (mappedUsers != null && mappedUsers.Any())
                {
                    return ServiceResponse<IEnumerable<UserResponseDto>>.SuccessResponse(mappedUsers, "تمت العملية بنجاح");
                }
                else
                {
                    return ServiceResponse<IEnumerable<UserResponseDto>>.FailureResponse("لا يوجد بيانات");
                }
            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<UserResponseDto>>.FailureResponse(ex.Message);
            }
        }
        public async Task<ServiceResponse<bool>> DeleteAsync(long id)
        {
            try
            {
                var result = await _userRepository.DeleteAsync(id);
                if (result)
                {
                    return ServiceResponse<bool>.SuccessResponse(result, "تم الحذف بنجاح");
                }
                else
                {
                    return ServiceResponse<bool>.FailureResponse("لم يتم الحذف");
                }
            }
            catch (Exception ex)
            {
                return ServiceResponse<bool>.FailureResponse(ex.Message);
            }
        }
        public async Task<ServiceResponse<bool>> AddUserToTeamAsync(long teamId, long userId)
        {
            try
            {
                var user = await _userRepository.AddUserToTeamAsync(teamId,userId);

                if (!user)
                {
                    return ServiceResponse<bool>.FailureResponse("لم تتم العملية بنجاح");
                }
                return ServiceResponse<bool>.SuccessResponse(true, "تمت العملية بنجاح");
            }
            catch (Exception ex)
            {
                return ServiceResponse<bool>.FailureResponse(ex.Message);
            }
        }
        public async Task<ServiceResponse<bool>> RemoveUserToTeamAsync(long userId)
        {
            try
            {
                var user = await _userRepository.RemoveUserToTeamAsync(userId);

                if (!user)
                {
                    return ServiceResponse<bool>.FailureResponse("لم تتم العملية بنجاح");
                }
                return ServiceResponse<bool>.SuccessResponse(true, "تمت العملية بنجاح");
            }
            catch (Exception ex)
            {
                return ServiceResponse<bool>.FailureResponse(ex.Message);
            }
        }
        
    }
}
