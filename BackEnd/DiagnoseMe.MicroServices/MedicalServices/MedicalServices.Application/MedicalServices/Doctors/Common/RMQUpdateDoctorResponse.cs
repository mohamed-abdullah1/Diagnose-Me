namespace MedicalServices.Application.MedicalServices.Doctors.Common;

public record RMQUpdateDoctorResponse(
    string Id,
    string Specialization,
    float Rating
);