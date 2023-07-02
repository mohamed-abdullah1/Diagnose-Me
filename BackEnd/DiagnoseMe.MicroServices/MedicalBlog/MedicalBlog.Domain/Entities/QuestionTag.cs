namespace MedicalBlog.Domain.Entities;

public class QuestionTag : BaseEntity
{
    public string TagId { get; set; } = string.Empty;
    public string QuestionId { get; set; } = string.Empty;
    public virtual Tag Tag { get; set; } = new();
    public virtual Question Question { get; set; } = new();
}