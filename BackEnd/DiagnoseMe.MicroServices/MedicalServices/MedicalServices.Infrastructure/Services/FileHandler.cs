using MedicalServices.Application.Common.Interfaces.Services;
using ErrorOr;

namespace MedicalServices.Infrastructure.Services;

public class FileHandler : IFileHandler
{
    public ErrorOr<string> SaveFile(byte[] file)
    {
        return "FakeUrl";
    }
}