namespace MedicalBlog.Persistence.Repositories;

public class PostTagRepository : BaseRepo<PostTag>, IPostTagRepository
{
    public PostTagRepository(DbContext db) : base(db)
    {
    }
}