using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalBlog.Persistence.Context.Configurations;


public class QuestionAgreementConfiguration : BaseConfiguration<QuestionAgreement>
{
    public override void Configure(EntityTypeBuilder<QuestionAgreement> builder=null!)
    {
        builder.ToTable("QuestionAgreements");
        builder.HasKey(qa => new { qa.UserId, qa.QuestionId });
        builder.Property(qa => qa.UserId).IsRequired();
        builder.Property(qa => qa.QuestionId).IsRequired();
        builder.Property(qa => qa.IsAgreed).IsRequired();
    }
}