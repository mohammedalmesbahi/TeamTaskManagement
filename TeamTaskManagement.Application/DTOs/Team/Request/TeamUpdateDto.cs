using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.DTOs.Base;

namespace TeamTaskManagement.Application.DTOs.Team.Request
{
    public class TeamUpdateDto: BaseUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
