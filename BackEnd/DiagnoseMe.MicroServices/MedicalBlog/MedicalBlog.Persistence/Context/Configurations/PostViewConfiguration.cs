using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalBlog.Persistence.Context.Configurations;

public class PostViewConfiguration : BaseConfiguration<PostView>
{
    public override void Configure(EntityTypeBuilder<PostView> builder=null!)
    {
        builder.ToTable("PostsView");
        builder.HasKey(mr => new { mr.UserId, mr.PostId });
        builder.Property(mr => mr.UserId).IsRequired();     
        builder.Property(mr => mr.PostId).IsRequired();
    }
}