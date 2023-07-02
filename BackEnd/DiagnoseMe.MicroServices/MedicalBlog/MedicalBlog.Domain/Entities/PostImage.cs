namespace MedicalBlog.Domain.Entities;

public class PostImage : BaseEntity
{
    public string ImageUrl { get; set; } = string.Empty;
    public string PostId { get; set; } = string.Empty;
    public virtual Post Post { get; set; } = new Post();
}