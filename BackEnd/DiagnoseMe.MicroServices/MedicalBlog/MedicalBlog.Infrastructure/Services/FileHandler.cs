using MedicalBlog.Application.Common.Interfaces.Services;
using ErrorOr;

namespace MedicalBlog.Infrastructure.Services;

public class FileHandler : IFileHandler
{
    public ErrorOr<bool> DeleteFile(string fileName)
    {
        return true;
    }

    public ErrorOr<string> SaveFile(byte[] file)
    {
        return "FakeUrl";
    }
}