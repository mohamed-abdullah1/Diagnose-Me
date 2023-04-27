using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalBlog.Persistence.Context.Configurations;


public class PostTagConfiguration : BaseConfiguration<PostTag>
{
    public override void Configure(EntityTypeBuilder<PostTag> builder)
    {
        builder.ToTable("PostTags");
        builder.HasKey(pt => new { pt.PostId, pt.TagId });
        builder.Property(pt => pt.PostId).IsRequired();
        builder.Property(pt => pt.TagId).IsRequired();
    }
}