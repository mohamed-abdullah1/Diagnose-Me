using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalBlog.Persistence.Context.Configurations;

public class QuestionTagConfiguration : BaseConfiguration<QuestionTag>
{
    public override void Configure(EntityTypeBuilder<QuestionTag> builder)
    {
        builder.ToTable("QuestionTags");
        builder.HasKey(qt => new { qt.QuestionId, qt.TagId });
        builder.Property(qt => qt.QuestionId).IsRequired();
        builder.Property(qt => qt.TagId).IsRequired();
    }
}