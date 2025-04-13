using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Domain.Common.Enums;

namespace TeamTaskManagement.Application.DTOs.User.Response
{
    public class UserResponseDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public EntityState State { get; set; } = EntityState.Active;
    }
}
