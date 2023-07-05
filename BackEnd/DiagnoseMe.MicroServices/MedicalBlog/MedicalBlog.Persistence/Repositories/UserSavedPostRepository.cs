namespace MedicalBlog.Persistence.Repositories;

public class UserSavedPostRepository : BaseRepo<UserSavedPost> , IUserSavedPostRepository
{
    public UserSavedPostRepository(DbContext db) : base(db)
    {
    }
}