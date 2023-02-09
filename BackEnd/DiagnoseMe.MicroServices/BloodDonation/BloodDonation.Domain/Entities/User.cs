using System;
namespace BloodDonation.Domain.Entities;


public class User : BaseEntity
{
    public string Name {get; set;} = string.Empty;
    public string FullName {get; set;} = string.Empty;
    public string ProfilePictureUrl {get; set;} = string.Empty;
    public string BloodType {get; set;} = string.Empty;
    public DateTime? LastDonationDate {get; set;} = null!;
    public virtual ICollection<DonationRequest> DonationRequests {get; set;} = new HashSet<DonationRequest>();
    public virtual ICollection<DonationRequest> Donations {get; set;} = new HashSet<DonationRequest>();
}