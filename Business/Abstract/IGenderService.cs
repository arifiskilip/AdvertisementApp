using Business.GenericServiceBase;
using Dtos.Concrete.GenderDto;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IGenderService : IGenericService<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>
    {
    }
}
