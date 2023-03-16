namespace MedicalBlog.Application.Common.Interfaces.Persistence;


public interface IUnitOfWork
{
    Task<int> Save();
}