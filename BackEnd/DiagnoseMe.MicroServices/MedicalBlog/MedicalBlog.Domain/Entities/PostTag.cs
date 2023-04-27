namespace MedicalBlog.Domain.Entities;

public class PostTag : BaseEntity
{
    public string TagId { get; set; } = string.Empty;
    public string PostId { get; set; } = string.Empty;
    public virtual Tag Tag { get; set; } = new();
    public virtual Post Post { get; set; } = new();
}