using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalBlog.Persistence.Context.Configurations;

public class PostImageConfiguration : BaseConfiguration<PostImage>
{
    public override void Configure(EntityTypeBuilder<PostImage> builder=null!)
    {
        builder.ToTable("PostImages");
        base.Configure(builder);
        builder.Property(c => c.ImageUrl).IsRequired();
        builder.Property(c => c.PostId).IsRequired();
        builder.HasOne(c => c.Post).WithMany(c => c.PostImages).HasForeignKey(c => c.PostId);
    }
}