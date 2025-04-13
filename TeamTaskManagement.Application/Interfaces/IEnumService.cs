using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.Common.Enum;
using TeamTaskManagement.Application.Common.Responses;
using TeamTaskManagement.Application.DTOs;

namespace TeamTaskManagement.Application.Interfaces
{
    public interface IEnumService
    {
        Task<ServiceResponse<List<EnumValueDto>>> GetEnumValuesList(EnumTypes EnumTypeId);
    }
}
