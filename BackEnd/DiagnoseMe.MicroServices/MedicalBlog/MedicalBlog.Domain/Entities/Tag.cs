namespace MedicalBlog.Domain.Entities;


public class Tag : BaseEntity
{
    public string TagName { get; set; } = string.Empty;
    public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
    public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
}