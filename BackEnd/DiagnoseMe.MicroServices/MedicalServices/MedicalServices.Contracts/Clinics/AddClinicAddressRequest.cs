namespace MedicalServices.Contracts.Clinics;

public record AddClinicAddressRequest(
    string ClinicId,
    string Name,
    string Street,
    string City,
    string State,
    string Country,
    string ZipCode,
    string Latitude,
    string Longitude,
    string OpenTime,
    string CloseTime,
    string Base64Picture
);