using API.Persistence.Repository.Implementation;
using API.Persistence.Repository.Interface;

namespace API.Persistence.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IUserRepo Users { get; }
    ICourseRepo Courses { get; }
    ITagRepo Tags { get; }
    IAlgorithmRepo Algorithms { get; }
    Task<int> SaveChangesAsync();
}
