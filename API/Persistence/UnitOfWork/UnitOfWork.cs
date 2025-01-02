using API.Persistence.Context;
using API.Persistence.Repository.Implementation;
using API.Persistence.Repository.Interface;

namespace API.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IUserRepo Users { get; }
    public ICourseRepo Courses { get;  }
    public ITagRepo Tags { get; }

    public IAlgorithmRepo Algorithms {get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Users = new UserRepo(_context);
        Courses = new CourseRepo(_context);
        Tags = new TagRepo(_context);
        Algorithms = new AlgorithmRepo(_context);
    }


    public void Dispose() => _context.Dispose();


    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

}
