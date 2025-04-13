using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Domain.Common;

namespace TeamTaskManagement.Domain.Entities
{
    public class Team: BaseEntityWithName
    {
        public string Description { get; set; }
        public virtual  ICollection<User> Users { get; set; }
        public virtual ICollection<TaskItem> Tasks { get; set; }
    }
}
