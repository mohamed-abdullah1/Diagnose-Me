namespace MedicalBlog.Persistence.Repositories;
public class CommentRepository : BaseRepo<Comment>, ICommentRepository
{
    public CommentRepository(DbContext db) : base(db)
    {
    }

    
}
