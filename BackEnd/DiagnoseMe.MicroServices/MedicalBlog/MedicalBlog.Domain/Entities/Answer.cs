namespace MedicalBlog.Domain.Entities;

public class Answer : BaseEntity
{ 
    public string AnswerString {get; set;} = string.Empty;
    public string AnsweringDoctorId {get; set;}  = string.Empty;
    public DateTime? ModifiedOn {get; set;}
    public  string QuestionId  {get; set;} = string.Empty;
    public int AgreementCount {get; set;}
    public virtual Question Question  {get; set;} = new();
    public virtual ICollection<User> AgreeingUsers {get; set;} = new HashSet<User>();
    public virtual User AnsweringDoctor {get; set;} = new User();    
} 