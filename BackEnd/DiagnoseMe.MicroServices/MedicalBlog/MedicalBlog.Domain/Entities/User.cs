using System;
namespace MedicalBlog.Domain.Entities;


public class User : BaseEntity
{
    public string Name {get; set;} = string.Empty;
    public string FullName {get; set;} = string.Empty;
    public string ProfilePictureUrl {get; set;} = string.Empty;
    public bool IsDoctor {get; set;} = false;
    public string? Specialization {get; set;}
    public float Rating {get; set;} = 0;
    public virtual ICollection<Answer> Answers {get; set;} = new HashSet<Answer>();
    public virtual ICollection<Comment> Comments {get; set;} = new HashSet<Comment>();
    public virtual ICollection<Comment> CommentAgreements {get; set;} = new HashSet<Comment>();
    public virtual ICollection<Answer> AnswerAgreements {get; set;} = new HashSet<Answer>();
    public virtual ICollection<Post> RatedPosts {get; set;} = new HashSet<Post>();
    public virtual ICollection<Post> Posts {get; set;} = new HashSet<Post>();
    public virtual ICollection<Post> PostViews {get; set;} = new HashSet<Post>();
    public virtual ICollection<Question> Questions {get; set;} = new HashSet<Question>();
    public virtual ICollection<Question> QuestionAgreements {get; set;} = new HashSet<Question>();
    public virtual ICollection<User> SubscribedUsers {get; set;} = new HashSet<User>();
    public virtual ICollection<User> Subscribers {get; set;} = new HashSet<User>();
    public virtual ICollection<Post> SavedPosts {get; set;} = new HashSet<Post>();
}