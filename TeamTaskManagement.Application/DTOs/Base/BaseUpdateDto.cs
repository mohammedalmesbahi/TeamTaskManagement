using TeamTaskManagement.Domain.Common.Enums;
namespace TeamTaskManagement.Application.DTOs.Base
{
    public class BaseUpdateDto : BaseEntityDto
    {
        public long Id { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public EntityState State { get; set; }
    }
}
