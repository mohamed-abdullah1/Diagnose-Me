namespace MedicalServices.Contracts.Doctors;


public record AddDoctorRequest(
    string Title,
    string Bio,
    string License,
    string ClinicId);