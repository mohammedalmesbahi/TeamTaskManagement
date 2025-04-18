using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Application.Common.Responses;
using TeamTaskManagement.Application.DTOs.Base;
using TeamTaskManagement.Application.Interfaces.Base;
using TeamTaskManagement.Domain.Common;
using TeamTaskManagement.Domain.Common.Enums;
using TeamTaskManagement.Domain.Interfaces;

namespace TeamTaskManagement.Application.Services.Base
{
    public abstract class BaseService<TEntity, TCreateDto, TUpdateDto, TEntityDto> : IBaseService<TEntity, TCreateDto, TUpdateDto, TEntityDto>
        where TEntity : BaseEntity
        where TEntityDto : BaseResponseDto
        where TCreateDto : BaseCreateDto
        where TUpdateDto : BaseUpdateDto
    {
        public readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<TEntityDto>> InsertAsync(TCreateDto dto)
        {
            await ValidationInsertRequest(dto);

            try
            {
                var entity = _mapper.Map<TEntity>(dto);
                var result = await _repository.InsertAsync(entity);
                var dtoResult = _mapper.Map<TEntityDto>(result);
                return ServiceResponse<TEntityDto>.SuccessResponse(dtoResult, "تمت الإضافة بنجاح");
            }
            catch (Exception ex)
            {
                return ServiceResponse<TEntityDto>.FailureResponse(ex.Message);
            }
        }
        public async Task<ServiceResponse<TEntityDto>> UpdateAsync(TUpdateDto dto)
        {
            await ValidationUpdateRequest(dto);
            try
            {
                var entity = _mapper.Map<TEntity>(dto);
                var res = _repository.Update(entity);
                var dtoResult = _mapper.Map<TEntityDto>(res);
                return ServiceResponse<TEntityDto>.SuccessResponse(dtoResult, "تم التعديل بنجاح");
            }
            catch (Exception ex)
            {
                return ServiceResponse<TEntityDto>.FailureResponse(ex.Message);
            }

        }
        public virtual async Task<ServiceResponse<IEnumerable<TEntityDto>>> GetAllAsync()
        {
            try
            {
                var entities = await _repository.FindAllAsync(s=>s.State==EntityState.Active || s.State==EntityState.Inactive);
                var dtoResult = _mapper.Map<IEnumerable<TEntityDto>>(entities);
                return ServiceResponse<IEnumerable<TEntityDto>>.SuccessResponse(dtoResult, "تمت العملية بنجاح");
            }
            catch (Exception ex)
            {
                return ServiceResponse<IEnumerable<TEntityDto>>.FailureResponse(ex.Message);
            }

        }
        public async Task<ServiceResponse<TEntityDto?>> GetByIdAsync(long id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                var dtoResult = _mapper.Map<TEntityDto>(entity);

                return ServiceResponse<TEntityDto?>.SuccessResponse(dtoResult, "تمت العملية بنجاح");
            }

            catch (Exception ex)
            {
                return ServiceResponse<TEntityDto?>.FailureResponse(ex.Message);
            }
        }
        public async Task<ServiceResponse<TEntityDto>> DeleteAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return ServiceResponse<TEntityDto>.FailureResponse("العنصر غير موجود");
            }

            var res = await _repository.DeleteAsync(id);
            return ServiceResponse<TEntityDto>.SuccessResponse(_mapper.Map<TEntityDto>(res), "تم الحذف بنجاح");
        }

        public async Task<ServiceResponse<int>> CountAsync()
        {
            var count = await _repository.CountAsync();
            return ServiceResponse<int>.SuccessResponse(count, "تمت العملية بنجاح");
        }


        public async Task<ServiceResponse<bool>> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var exists = await _repository.ExistsAsync(predicate);
            return ServiceResponse<bool>.SuccessResponse(exists, exists ? "تم العثور" : "لم يتم العثور");
        }

        public async Task<ServiceResponse<TEntityDto?>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _repository.FindAsync(predicate);
            if (entity == null)
            {
                return ServiceResponse<TEntityDto?>.FailureResponse("العنصر غير موجود");
            }

            return ServiceResponse<TEntityDto?>.SuccessResponse(_mapper.Map<TEntityDto>(entity), "تمت العملية بنجاح");
        }
        public async Task<ServiceResponse<IEnumerable<TEntityDto>>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await _repository.FindAllAsync(predicate);
            if (entities == null || !entities.Any())
            {
                return ServiceResponse<IEnumerable<TEntityDto>>.FailureResponse("لم يتم العثور");
            }

            return ServiceResponse<IEnumerable<TEntityDto>>.SuccessResponse(_mapper.Map<IEnumerable<TEntityDto>>(entities), "تم العثور");
        }
        protected abstract Task ValidationInsertRequest(TCreateDto dto);
        protected abstract Task ValidationUpdateRequest(TUpdateDto dto);


    }
}
