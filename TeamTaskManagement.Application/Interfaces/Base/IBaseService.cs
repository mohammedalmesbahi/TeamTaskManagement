using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.Common.Responses;
using TeamTaskManagement.Application.DTOs.Base;
using TeamTaskManagement.Domain.Common;

namespace TeamTaskManagement.Application.Interfaces.Base
{
    public interface IBaseService<TEntity, TCreateDto, TUpdateDto, TEntityDto>
           where TEntity : BaseEntity
           where TEntityDto : BaseEntityDto
           where TCreateDto : BaseCreateDto
           where TUpdateDto : BaseUpdateDto
    {
        Task<ServiceResponse<TEntityDto>> InsertAsync(TCreateDto dto);
        Task<ServiceResponse<TEntityDto>> UpdateAsync(TUpdateDto dto);
        Task<ServiceResponse<IEnumerable<TEntityDto>>> GetAllAsync();
        Task<ServiceResponse<TEntityDto?>> GetByIdAsync(long id);
        Task<ServiceResponse<TEntityDto>> DeleteAsync(long id);
        Task<ServiceResponse<int>> CountAsync();
        Task<ServiceResponse<bool>> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ServiceResponse<TEntityDto?>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ServiceResponse<IEnumerable<TEntityDto>>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
