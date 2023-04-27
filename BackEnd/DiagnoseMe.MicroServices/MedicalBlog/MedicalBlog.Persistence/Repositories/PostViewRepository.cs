namespace MedicalBlog.Persistence.Repositories;

public class PostViewRepository : BaseRepo<PostView>, IPostViewRepository
{
    public PostViewRepository(DbContext db) : base(db)
    {
    }  
 
}