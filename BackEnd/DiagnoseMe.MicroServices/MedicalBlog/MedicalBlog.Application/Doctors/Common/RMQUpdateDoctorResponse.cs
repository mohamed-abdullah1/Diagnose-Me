namespace MedicalBlog.Application.Doctors.Common;

public record RMQUpdateDoctorResponse(
    string Id,
    string Specialization,
    float Rating
);