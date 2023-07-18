using Common.Responses;
using Dtos.Abstract;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.GenericServiceBase
{
    public interface IGenericService<CreateDto, UpdateDto, ListDto,T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity, new()
    {
        Task<IResponse<CreateDto>> AddAsync(CreateDto entity);
        Task<IResponse> UpdateAsync(UpdateDto entity);
        Task<IResponse> DeleteAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
        Task<IResponse<ListDto>> GetByIdAsync(int id);
    }
}
