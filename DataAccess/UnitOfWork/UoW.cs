using DataAccess.Contexts;
using DataAccess.GenericRepositoryBase;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UoW : IUoW
    {
        private readonly AdvertisementContext _context;

        public UoW(AdvertisementContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IGenericRepository<T> GetRepository<T>() where T:class , new()
        {
            return new GenericRepository<T>(_context);
        }
    }
}
