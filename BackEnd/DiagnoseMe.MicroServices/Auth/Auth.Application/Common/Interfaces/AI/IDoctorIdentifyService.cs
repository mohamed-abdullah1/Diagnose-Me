namespace Auth.Application.Common.Interfaces.AI;


public interface IDoctorIdentifyService
{
    Task<ErrorOr<bool>> CheckIfDoctor(string base64License);
}