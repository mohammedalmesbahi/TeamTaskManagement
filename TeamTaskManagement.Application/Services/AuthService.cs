using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.Common.Responses;
using TeamTaskManagement.Application.DTOs.Auth.Request;
using TeamTaskManagement.Application.DTOs.Auth.Response;
using TeamTaskManagement.Application.Interfaces;
using TeamTaskManagement.Domain.Entities;

namespace TeamTaskManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }
        public async Task<ServiceResponse<SignInResponseDto>> SignInAsync(SignInRequestDto signInDto)
        {
            var user = await _userManager.FindByNameAsync(signInDto.Username);
            if (user == null)
            {
                return ServiceResponse<SignInResponseDto>.FailureResponse("اسم المستخدم غير صحيح");
            }

            if (!await _userManager.CheckPasswordAsync(user, signInDto.Password))
            {
                return ServiceResponse<SignInResponseDto>.FailureResponse("كلمة المرور غير صحيحة");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles == null || !userRoles.Any())
            {
                return ServiceResponse<SignInResponseDto>.FailureResponse("المستخدم ليس لديه أي صلاحية");
            }

            var claims = new List<Claim>
            {
              new Claim(ClaimTypes.Name, user.UserName),
              new Claim(ClaimTypes.Role, userRoles.First())
            };
            string token = GenerateToken(claims);
            var dtoResponse = new SignInResponseDto
            {
                Token = token,
                Id = user.Id,
                Username = user.UserName,
                Name = user.Name,
                Role = userRoles.First(),
                PhoneNumber = user.PhoneNumber,
                ExpiresOn = DateTime.UtcNow.AddDays(1)
            };
            return ServiceResponse<SignInResponseDto>.SuccessResponse(dtoResponse, "تم تسجيل الدخول بنجاح");
        }

        public async Task<ServiceResponse<SignUpResponseDto>> SignUpAsync(SignUpRequestDto model)
        {
                var existingUser = await _userManager.FindByNameAsync(model.UserName);
                if (existingUser != null)
                {
                    return ServiceResponse<SignUpResponseDto>.FailureResponse("اسم المستخدم موجود بالفعل");
                }
                var user = new User
                {
                    UserName = model.UserName,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,

                };
                var createUserResult = await _userManager.CreateAsync(user, model.Password);
                if (!createUserResult.Succeeded)
                {
                    var errors = string.Join(", ", createUserResult.Errors.Select(e => e.Description));
                    return ServiceResponse<SignUpResponseDto>.FailureResponse(errors);
                }

                if (!await _roleManager.RoleExistsAsync(model.Role))
                    await _roleManager.CreateAsync(new Role { Name = model.Role });

                await _userManager.AddToRoleAsync(user, model.Role);

                var dto = new SignUpResponseDto
                {
                    UserName = user.UserName,
                    Name = user.Name,
                    Role = model.Role,
                    PhoneNumber = user.PhoneNumber,
                };

                return ServiceResponse<SignUpResponseDto>.SuccessResponse(dto, "تم التسجيل بنجاح");
        }


        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTKey:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWTKey:ValidIssuer"],
                Audience = _configuration["JWTKey:ValidAudience"],
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
