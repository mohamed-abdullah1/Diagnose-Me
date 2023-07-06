namespace BloodDonation.Domain.Entities;

public class DonationRequest : BaseEntity
{
    public string RequesterId {get; set;} = string.Empty;
    public string BloodType {get; set;} = string.Empty;
    public string Type {get; set;} = string.Empty;
    public string Location {get; set;} = string.Empty;
    public string Reason {get; set;} = string.Empty;
    public string Status {get; set;} = string.Empty;
    public virtual User Requester {get; set;} = new User();
    public virtual ICollection<User> Donners {get; set;} = new HashSet<User>();
}