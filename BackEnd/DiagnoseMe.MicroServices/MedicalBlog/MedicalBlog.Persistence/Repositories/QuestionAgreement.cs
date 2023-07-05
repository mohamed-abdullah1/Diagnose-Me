namespace MedicalBlog.Persistence.Repositories;

public class QuestionAgreementRepository : BaseRepo<QuestionAgreement>, IQuestionAgreementRepository
{
    public QuestionAgreementRepository(DbContext db) : base(db)
    {
    }
}