namespace MedicalBlog.Domain.Entities;

public class QuestionAgreement : BaseEntity{

    public string UserId {get;set;} = string.Empty;
    public string QuestionId {get;set;} = string.Empty;
    public bool IsAgreed { get; set; } 
    public virtual Question Question {get; set;} = new();
    public virtual User User {get; set;} = new();
}