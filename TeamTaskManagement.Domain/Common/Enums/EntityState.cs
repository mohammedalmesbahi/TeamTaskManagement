using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTaskManagement.Domain.Common.Enums
{
    public enum EntityState
    {
        [Description("فعال")]
        Active = 1,
        [Description("غير فعال")]
        Inactive = 2,
        [Description("محذوف")]
        Deleted = 3
    }
}
