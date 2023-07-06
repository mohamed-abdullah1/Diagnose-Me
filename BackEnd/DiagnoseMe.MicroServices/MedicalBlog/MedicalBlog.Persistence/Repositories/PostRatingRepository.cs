namespace MedicalBlog.Persistence.Repositories;
public class PostRatingRepository : BaseRepo<PostRating>, IPostRatingRepository
{
    public PostRatingRepository(DbContext db) : base(db)
    {
    }

}
