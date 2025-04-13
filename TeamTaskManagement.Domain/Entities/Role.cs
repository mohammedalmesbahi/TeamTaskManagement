using Microsoft.AspNetCore.Identity;
using TeamTaskManagement.Domain.Common.Enums;

namespace TeamTaskManagement.Domain.Entities
{
    public class Role : IdentityRole<long>
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public EntityState State { get; set; } = EntityState.Active;
    }
}
