using Business.GenericServiceBase;
using Dtos.Concrete.ProvidedServiceDto;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProvidedServiceService : IGenericService<ProvidedServiceCreateDto,ProvidedServiceUpdateDto,ProvidedServiceListDto,ProvidedService>
    {
    }
}
