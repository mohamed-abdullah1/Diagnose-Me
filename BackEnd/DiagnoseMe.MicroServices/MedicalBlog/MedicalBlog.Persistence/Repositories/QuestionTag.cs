namespace MedicalBlog.Persistence.Repositories;

public class QuestionTagRepository : BaseRepo<QuestionTag>, IQuestionTagRepository
{
    public QuestionTagRepository(DbContext db) : base(db)
    {
    }
}