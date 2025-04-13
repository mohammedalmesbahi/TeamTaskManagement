using Microsoft.AspNetCore.Identity;
using TeamTaskManagement.Domain.Common.Enums;
namespace TeamTaskManagement.Domain.Entities
{
    public class User:IdentityUser<long>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public EntityState State { get; set; } = EntityState.Active;
        public long? TeamId { get; set; }
        public virtual Team? Team { get; set; }
        public virtual ICollection<TaskItem> TaskItems { get; set; } 

    }
}
