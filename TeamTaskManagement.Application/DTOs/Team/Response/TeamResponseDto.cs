using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.DTOs.Base;
using TeamTaskManagement.Application.DTOs.TaskItem.Response;
using TeamTaskManagement.Application.DTOs.User.Response;

namespace TeamTaskManagement.Application.DTOs.Team.Response
{
    public class TeamResponseDto : BaseResponseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public  List<UserResponseDto> Users { get; set; }
        public  List<TaskItemResponseDto> Tasks { get; set; }
    }
}
