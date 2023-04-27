namespace MedicalBlog.Domain.Entities;

public class Post : BaseEntity{

    public string Title {get; set;} = string.Empty;
    public string Content {get; set;} = string.Empty;
    public DateTime? ModifiedOn {get; set;}
    public float AverageRate {get; set;}
    public int ViewsCount {get; set;}
    public virtual ICollection<User> RatingUsers {get; set;} = new HashSet<User>();
    public virtual ICollection<User> ViewingUsers {get; set;} = new HashSet<User>();
    public string AuthorId {get; set;} = string.Empty;
    public virtual ICollection<Comment> Comments {get; set;} = new HashSet<Comment>();
    public virtual User Author {get; set;} = new User(); 
    public virtual ICollection<Tag> Tags {get; set;} = new HashSet<Tag>();
}