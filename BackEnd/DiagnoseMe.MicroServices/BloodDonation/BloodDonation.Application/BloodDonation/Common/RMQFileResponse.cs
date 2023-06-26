using Microsoft.AspNetCore.Http;

namespace BloodDonation.Application.BloodDonation.Common;
public record RMQFileResponse(
    string FilePath,
    IFormFile File
);