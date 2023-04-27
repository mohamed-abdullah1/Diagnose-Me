namespace MedicalBlog.Domain.Entities;

public class UserSubscribedUser : BaseEntity
{
    public string SubscriberId {get; set;} = string.Empty;
    public virtual User Subscriber {get; set;} = new();
    public string SubscribedUserId {get; set;} = string.Empty;
    public virtual User SubscribedUser {get; set;} = new();
}