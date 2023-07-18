using AutoMapper;
using Business.Extensions;
using Common.Responses;
using DataAccess.UnitOfWork;
using Dtos.Abstract;
using Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.GenericServiceBase
{
    public class GenericManager<CreateDto, UpdateDto, ListDto,T> : IGenericService<CreateDto, UpdateDto, ListDto,T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IDto, new()
        where ListDto : class, IDto, new()
        where T:BaseEntity, new()
    {
        private readonly IUoW _uoW;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _creatValidator;
        private readonly IValidator<UpdateDto> _updateValidator;

        public GenericManager(IUoW uoW, IMapper mapper, IValidator<CreateDto> creatValidator, IValidator<UpdateDto> updateValidator)
        {
            _uoW = uoW;
            _mapper = mapper;
            _creatValidator = creatValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IResponse<CreateDto>> AddAsync(CreateDto entity)
        {
            var result = _creatValidator.Validate(entity);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(entity);
                await _uoW.GetRepository<T>().AddAsync(createdEntity);
                await _uoW.CommitAsync();
                return new Response<CreateDto>(ResponseType.Success,entity);
            }
            return new Response<CreateDto>(entity,result.ConvertToCustomeValidationError());
        }

        public async Task<IResponse> DeleteAsync(int id)
        {
            var deletedData = await _uoW.GetRepository<T>().GetByIdAsync(id);
            if (deletedData != null)
            {
                _uoW.GetRepository<T>().Delete(deletedData);
                await _uoW.CommitAsync();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound,$"İlgili {id} bulunamadı!");     
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var data = await _uoW.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<ListDto>>(data);
            return new Response<List<ListDto>>(ResponseType.Success, dto);
            
        }

        public async Task<IResponse<ListDto>> GetByIdAsync(int id)
        {
            var data = await _uoW.GetRepository<T>().GetByIdAsync(id);
            if (data != null)
            {
                var dto = _mapper.Map<ListDto>(data);
                return new Response<ListDto>(ResponseType.Success, dto);
            }
            return new Response<ListDto>(ResponseType.NotFound, $"İlgili {id} bulunamadı!");
        }

        public async Task<IResponse> UpdateAsync(UpdateDto entity)
        {
            var result = _updateValidator.Validate(entity);
            if (result.IsValid)
            {
                var unchangeData = await _uoW.GetRepository<T>().GetByIdAsync(entity.Id);
                if (unchangeData == null)
                {
                    return new Response<UpdateDto>(ResponseType.NotFound, $"İlgili {entity.Id} bulunamadı!");
                }
                var data = _mapper.Map<T>(unchangeData);
                _uoW.GetRepository<T>().Update(data);
                await _uoW.CommitAsync();
                return new Response<UpdateDto>(ResponseType.Success, entity);
            }
            return new Response<UpdateDto>(entity, result.ConvertToCustomeValidationError());

        }
    }
}
