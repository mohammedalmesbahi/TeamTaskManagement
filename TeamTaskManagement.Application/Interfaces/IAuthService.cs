using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.Common.Responses;
using TeamTaskManagement.Application.DTOs.Auth.Request;
using TeamTaskManagement.Application.DTOs.Auth.Response;

namespace TeamTaskManagement.Application.Interfaces
{
    public interface IAuthService
    {
      public  Task<ServiceResponse<SignInResponseDto>> SignInAsync(SignInRequestDto dto);
        public Task<ServiceResponse<SignUpResponseDto>> SignUpAsync(SignUpRequestDto model);

    }
}
