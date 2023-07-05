namespace MedicalBlog.Persistence.Repositories;
 
 public class TagRepository : BaseRepo<Tag>, ITagRepository
 {
     public TagRepository(DbContext db) : base(db)
    {
    }
 }