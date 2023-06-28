namespace BloodDonation.Domain.Entities;

public class DonationRequest : BaseEntity
{
    public string RequesterId {get; set;} = string.Empty;
    public string BloodType {get; set;} = string.Empty;
    public string Location {get; set;} = string.Empty;
    public string Reason {get; set;} = string.Empty;
    public string Status {get; set;} = string.Empty;
    public string DonnerId {get; set;} = null!;
    public virtual User Requester {get; set;} = new User();
    public virtual User? Donner {get; set;} 
    public virtual ICollection<DonnerDonationRequest> DonnerDonationRequests {get; set;} = new HashSet<DonnerDonationRequest>();
}