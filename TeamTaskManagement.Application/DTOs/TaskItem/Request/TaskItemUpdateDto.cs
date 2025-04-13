using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.DTOs.Base;
using TeamTaskManagement.Domain.Common.Enums;

namespace TeamTaskManagement.Application.DTOs.TaskItem.Request
{
    public class TaskItemUpdateDto: BaseUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public long TeamId { get; set; }
        public TaskProgressStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public PriorityLevel? PriorityLevel { get; set; }
    }
}
