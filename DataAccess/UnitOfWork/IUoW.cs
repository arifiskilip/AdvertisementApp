using DataAccess.GenericRepositoryBase;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUoW
    {
        IGenericRepository<T> GetRepository<T>() where T: class, new();
        Task CommitAsync();
        void Commit();
    }
}
