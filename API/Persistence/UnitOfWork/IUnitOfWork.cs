using API.Persistence.Repository.Implementation;
using API.Persistence.Repository.Interface;

namespace API.Persistence.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IUserRepo Users { get; }
    Task<int> SaveChangesAsync();
}
