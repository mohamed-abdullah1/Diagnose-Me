using Auth.Application.Common.Interfaces.AI;

namespace Auth.Application.AI;

public class DoctorIdentifyService : IDoctorIdentifyService
{
    public async Task<ErrorOr<bool>> CheckIfDoctor(string base64License)
    {
        // TODO: Implement AI service
        await Task.CompletedTask;
        return true;
    }
}