namespace MedicalBlog.Application.Common.Interfaces.Persistence.IUnitOfWork;


public interface IUnitOfWork
{
    Task<int> Save();
}