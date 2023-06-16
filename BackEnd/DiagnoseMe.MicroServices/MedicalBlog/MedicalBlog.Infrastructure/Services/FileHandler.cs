using MedicalBlog.Application.Common.Interfaces.Services;
using ErrorOr;

namespace MedicalBlog.Infrastructure.Services;

public class FileHandler : IFileHandler
{
    public ErrorOr<bool> DeleteFile(string fileName)
    {
        throw new NotImplementedException();
    }

    public ErrorOr<string> SaveFile(byte[] file)
    {
        throw new NotImplementedException();
    }
}