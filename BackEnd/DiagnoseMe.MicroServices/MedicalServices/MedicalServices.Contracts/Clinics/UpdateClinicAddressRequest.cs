namespace MedicalServices.Contracts.Clinics;

public record UpdateClinicAddressRequest(
    string ClinicAddressId,
    string Name,
    string Street,
    string City,
    string State,
    string Country,
    string ZipCode,
    string OpenTime,
    string CloseTime
);