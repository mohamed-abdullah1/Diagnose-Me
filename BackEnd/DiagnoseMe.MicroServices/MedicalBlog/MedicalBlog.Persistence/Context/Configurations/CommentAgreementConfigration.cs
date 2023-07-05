using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalBlog.Persistence.Context.Configurations;

public class CommentAgreementConfigration : BaseConfiguration<CommentAgreement>
{
    public override void Configure(EntityTypeBuilder<CommentAgreement> builder=null!)
    {
        builder.ToTable("CommentAgreements");
        builder.HasKey(c => new { c.UserId, c.CommentId });
        builder.Property(c => c.IsAgreed).IsRequired();
        builder.Property(c => c.UserId).IsRequired();
        builder.Property(c => c.CommentId).IsRequired();
    }
}