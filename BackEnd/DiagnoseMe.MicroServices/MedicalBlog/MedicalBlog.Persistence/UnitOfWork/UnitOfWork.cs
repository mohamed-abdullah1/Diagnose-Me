using MedicalBlog.Application.Common.Interfaces.Persistence.IUnitOfWork;

namespace MedicalBlog.Persistence;


public class UnitOfWork : IUnitOfWork, IDisposable
{
    private DbContext _context;

    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    public async void Dispose()
    {
        await _context.DisposeAsync();
    }

    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }
}