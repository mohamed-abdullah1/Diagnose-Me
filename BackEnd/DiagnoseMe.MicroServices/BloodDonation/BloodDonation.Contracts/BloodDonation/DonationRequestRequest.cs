namespace BloodDonation.Contracts.BloodDonation;

public record DonationRequestRequest(
    string BloodType,
    string Type,
    string Location,
    string Reason);