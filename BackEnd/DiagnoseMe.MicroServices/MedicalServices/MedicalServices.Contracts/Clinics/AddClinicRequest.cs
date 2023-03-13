namespace MedicalServices.Contracts.Clinics;


public record AddClinicRequest(
    string Specialization,
    string Description,
    string Base64Picture
);