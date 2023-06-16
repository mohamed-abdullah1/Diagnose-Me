namespace MedicalBlog.Domain.Entities;

public class UserSavedPost : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public virtual User User { get; set; } = new User();
    public string PostId { get; set; } = string.Empty;
    public virtual Post Post { get; set; } = new Post();
}