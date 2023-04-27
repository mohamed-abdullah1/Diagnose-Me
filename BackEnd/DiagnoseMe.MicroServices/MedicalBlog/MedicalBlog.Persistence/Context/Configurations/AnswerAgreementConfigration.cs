using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalBlog.Persistence.Context.Configurations;
public class AnswerAgreementsConfigration : BaseConfiguration<AnswerAgreement>
{
    public override void Configure(EntityTypeBuilder<AnswerAgreement> builder=null!)
    {
        builder.ToTable("AnswerAgreements");
        builder.HasKey(c => new { c.UserId, c.AnswerId });
        builder.Property(c => c.IsAgreed).IsRequired(); 
        builder.Property(c => c.AnswerId).IsRequired();
        builder.Property(c => c.UserId).IsRequired();       
    }
}
