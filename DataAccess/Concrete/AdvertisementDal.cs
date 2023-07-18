using DataAccess.Abstract;
using DataAccess.Contexts;
using DataAccess.GenericRepositoryBase;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class AdvertisementDal : GenericRepository<Advertisement>, IAdvertisementDal
    {
        private readonly AdvertisementContext _context;
        public AdvertisementDal(AdvertisementContext context) : base(context)
        {
            _context = context;
        }
    }
}
