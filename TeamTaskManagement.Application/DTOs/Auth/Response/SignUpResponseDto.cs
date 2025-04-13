using TeamTaskManagement.Domain.Common.Enums;

namespace TeamTaskManagement.Application.DTOs.Auth.Response
{
    public class SignUpResponseDto
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public EntityState State { get; set; } = EntityState.Active;
    }
}
