namespace MedicalServices.Contracts.Doctors;

public record UpdateDoctorRequest(
    string Title,
    string Bio);