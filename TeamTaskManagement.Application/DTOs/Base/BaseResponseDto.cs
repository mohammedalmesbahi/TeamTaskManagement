using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Domain.Common.Enums;

namespace TeamTaskManagement.Application.DTOs.Base
{
    public class BaseResponseDto:BaseEntityDto
    {
        public long? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public EntityState State { get; set; }
    }
}
