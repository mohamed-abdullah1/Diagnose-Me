using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalBlog.Persistence.Context.Configurations;


public class TagConfiguration : BaseConfiguration<Tag>
{
    public override void Configure(EntityTypeBuilder<Tag> builder=null!)
    {
        builder.ToTable("Tags");
        base.Configure(builder);
        builder.Property(t => t.TagName).IsRequired();
        builder.HasIndex(t => t.TagName).IsUnique(); 
        builder.HasMany(t => t.Posts)
            .WithMany(q => q.Tags)
            .UsingEntity<PostTag>(
                j => j.HasOne(u => u.Post)
                    .WithMany()
                    .HasForeignKey(u => u.PostId)
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(u => u.Tag)
                    .WithMany()
                    .HasForeignKey(u => u.TagId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(t => t.Questions)
            .WithMany(q => q.Tags)
            .UsingEntity<QuestionTag>(
                j => j.HasOne(u => u.Question)
                    .WithMany()
                    .HasForeignKey(u => u.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(u => u.Tag)
                    .WithMany()
                    .HasForeignKey(u => u.TagId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
   }
}