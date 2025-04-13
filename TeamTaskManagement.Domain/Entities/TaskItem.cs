
using TeamTaskManagement.Domain.Common;
using TeamTaskManagement.Domain.Common.Enums;

namespace TeamTaskManagement.Domain.Entities
{
    public class TaskItem :BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long TeamId { get; set; }
        public virtual Team Team { get; set; }
        public TaskProgressStatus Status { get; set; } = TaskProgressStatus.New;
        public PriorityLevel PriorityLevel { get; set; } = PriorityLevel.Normal;
        public DateTime DueDate { get; set; }
    }
}
