using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.DTOs.Base;

namespace TeamTaskManagement.Application.DTOs.Role.Request
{
    public class RoleCreateDto: BaseCreateDto
    {
        public string Name { get; set; } 
    }
}
