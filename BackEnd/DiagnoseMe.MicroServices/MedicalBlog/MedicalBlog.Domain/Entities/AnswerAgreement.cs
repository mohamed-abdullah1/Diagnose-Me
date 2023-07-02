namespace MedicalBlog.Domain.Entities;
public class AnswerAgreement : BaseEntity{

    public bool IsAgreed {get; set;}
    public string UserId {get; set;} = string.Empty;
    public string AnswerId {get; set;} = string.Empty;
    public virtual Answer Answer  {get; set;} = new();
    public virtual User User {get; set;} = new();
}