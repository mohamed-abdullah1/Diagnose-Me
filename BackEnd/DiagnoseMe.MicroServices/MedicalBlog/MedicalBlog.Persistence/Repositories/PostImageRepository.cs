namespace MedicalBlog.Persistence.Repositories;

public class PostImageRepository : BaseRepo<PostImage>, IPostImageRepository
{
    public PostImageRepository(DbContext db) : base(db)
    {
    }
}