namespace Auth.Contracts.Authentication;

public record VerifyDoctorIdentityRequest(
    string Base64License
);