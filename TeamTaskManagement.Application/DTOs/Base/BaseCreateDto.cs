using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Domain.Common.Enums;

namespace TeamTaskManagement.Application.DTOs.Base
{
    public class BaseCreateDto : BaseEntityDto
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public EntityState State { get; set; } = EntityState.Active;
    }
}
