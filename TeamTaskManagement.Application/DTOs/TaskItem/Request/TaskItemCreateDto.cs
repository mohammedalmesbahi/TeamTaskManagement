using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.DTOs.Base;
using TeamTaskManagement.Application.DTOs.Team.Response;
using TeamTaskManagement.Application.DTOs.User.Response;
using TeamTaskManagement.Domain.Common.Enums;

namespace TeamTaskManagement.Application.DTOs.TaskItem.Request
{
    public class TaskItemCreateDto: BaseCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public long TeamId { get; set; }
        public DateTime DueDate { get; set; }
        public PriorityLevel? PriorityLevel { get; set; } 
    }
}
