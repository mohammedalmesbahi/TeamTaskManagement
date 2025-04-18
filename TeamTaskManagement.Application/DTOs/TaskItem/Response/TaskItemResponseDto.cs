using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.DTOs.Base;
using TeamTaskManagement.Application.DTOs.Team.Response;
using TeamTaskManagement.Application.DTOs.User.Response;
using TeamTaskManagement.Domain.Common.Enums;

namespace TeamTaskManagement.Application.DTOs.TaskItem.Response
{
    public class TaskItemResponseDto: BaseResponseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public UserResponseDto User { get; set; }
        public long TeamId { get; set; }
        public  TeamResponseDto Team { get; set; }
        public TaskProgressStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public PriorityLevel? PriorityLevel { get; set; }
    }
}
