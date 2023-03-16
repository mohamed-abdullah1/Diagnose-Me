using MedicalBlog.Application.Common.Interfaces.Persistence;
using MedicalBlog.Persistence.Context;

namespace MedicalBlog.Persistence;


public class UnitOfWork : IUnitOfWork, IDisposable
{
    private ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
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