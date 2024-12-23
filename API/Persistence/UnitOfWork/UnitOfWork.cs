using API.Persistence.Context;
using API.Persistence.Repository.Implementation;
using API.Persistence.Repository.Interface;

namespace API.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public UserRepo Users { get; }
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Users = new UserRepo(_context);
    }


    public void Dispose() => _context.Dispose();


    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

}
