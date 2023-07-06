namespace BloodDonation.Domain.Entities;

public class DonnerDonationRequest : BaseEntity
{
    public string DonnerId {get; set;} = string.Empty;
    public virtual User Donner {get; set;} = null!;
    public string Status {get; set;} = string.Empty;

    public string DonationRequestId {get; set;} = string.Empty;
    public virtual DonationRequest DonationRequest {get; set;} = null!;
}