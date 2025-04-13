using System.ComponentModel;
using System.Reflection;
using TeamTaskManagement.Application.Common.Enum;
using TeamTaskManagement.Application.Common.Responses;
using TeamTaskManagement.Application.DTOs;
using TeamTaskManagement.Application.Interfaces;
using TeamTaskManagement.Domain.Common.Enums;

namespace TeamTaskManagement.Application.Services
{
    public class EnumService : IEnumService
    {
        public async Task<ServiceResponse<List<EnumValueDto>>> GetEnumValuesList(EnumTypes enumTypeId)
        {
            List<EnumValueDto> list = null;

            if (enumTypeId == EnumTypes.EntityState)
            {
                list = GetEnumValuesList<EntityState>();
            }
            else if (enumTypeId == EnumTypes.TaskStatus)
            {
                list = GetEnumValuesList<TaskProgressStatus>();
            }
            else if (enumTypeId == EnumTypes.PriorityLevel)
            {
                list = GetEnumValuesList<PriorityLevel>();
            }

            if (list == null || !list.Any())
            {
                return ServiceResponse<List<EnumValueDto>>.FailureResponse("لا توجد قيم لهذا النوع من الـ Enum.");
            }

            return ServiceResponse<List<EnumValueDto>>.SuccessResponse(list);
        }
        public List<EnumValueDto> GetEnumValuesList<TEnumType>() where TEnumType : Enum
        {
            var enumValues = Enum.GetValues(typeof(TEnumType)).Cast<TEnumType>();

            var list = enumValues.Select(val => new EnumValueDto
            {
                Id = Convert.ToInt32(val),
                NameEn = val.ToString(),
                NameAr = GetEnumDescription(val)
            }).ToList();

            return list;
        }

        public string GetEnumDescription<TEnumType>(TEnumType value) where TEnumType : Enum
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}
