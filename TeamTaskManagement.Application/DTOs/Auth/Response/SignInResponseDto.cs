using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTaskManagement.Application.DTOs.Auth.Response
{
    public class SignInResponseDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
