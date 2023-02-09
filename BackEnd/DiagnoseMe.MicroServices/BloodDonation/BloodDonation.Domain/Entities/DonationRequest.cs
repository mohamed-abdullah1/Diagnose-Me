namespace BloodDonation.Domain.Entities;

public class DonationRequest : BaseEntity
{
    public string UserId {get; set;} = string.Empty;
    public string BloodType {get; set;} = string.Empty;
    public string Hospital {get; set;} = string.Empty;
    public string Reason {get; set;} = string.Empty;
    public string Status {get; set;} = string.Empty;
    public string DonatorUserId {get; set;} = null!;
    public virtual User User {get; set;} = new User();
    public virtual User DonatorUser {get; set;} = null!;
}