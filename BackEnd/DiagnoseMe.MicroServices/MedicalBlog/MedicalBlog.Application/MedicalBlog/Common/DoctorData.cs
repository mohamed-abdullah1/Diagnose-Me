namespace MedicalBlog.Application.MedicalBlog.Common;

public record DoctorData(
    string Id,
    string Name,
    string FullName,
    string ProfilePictureUrl,
    string Specialization,
    float Rating);