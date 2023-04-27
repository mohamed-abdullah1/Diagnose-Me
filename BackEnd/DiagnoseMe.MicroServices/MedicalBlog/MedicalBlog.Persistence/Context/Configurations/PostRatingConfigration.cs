using System.Threading;


using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalBlog.Persistence.Context.Configurations;

public class PostRatingConfigration : BaseConfiguration<PostRating>
{
    public override void Configure(EntityTypeBuilder<PostRating> builder=null!)
    {
        builder.ToTable("PostsRating");
        builder.HasKey(mr => new { mr.UserId, mr.PostId });
        builder.Property(mr => mr.Rating).IsRequired().HasMaxLength(15);
        builder.Property(mr => mr.UserId).IsRequired();     
        builder.Property(mr => mr.PostId).IsRequired();
    }
}
