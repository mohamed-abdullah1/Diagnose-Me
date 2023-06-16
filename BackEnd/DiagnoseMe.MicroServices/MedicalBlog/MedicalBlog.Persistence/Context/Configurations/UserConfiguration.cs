using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MedicalBlog.Persistence.Context.Configurations;

public class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder=null!)
    {
        builder.ToTable("Users");
        base.Configure(builder);
        builder.Property(c => c.Name).IsRequired();  
        builder.Property(c => c.ProfilePictureUrl).IsRequired();
        builder.Property(c => c.FullName).IsRequired();
        builder.HasMany(u => u.SubscribedUsers)
            .WithMany(u => u.Subscribers)
            .UsingEntity<UserSubscribedUser>(
                j => j.HasOne(u => u.Subscriber)
                    .WithMany()
                    .HasForeignKey(u => u.SubscriberId)
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(u => u.SubscribedUser)
                    .WithMany()
                    .HasForeignKey(u => u.SubscribedUserId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(u => u.AnswerAgreements)
            .WithMany(a => a.AgreeingUsers)
            .UsingEntity<AnswerAgreement>(
                j => j.HasOne(u => u.Answer)
                    .WithMany()
                    .HasForeignKey(u => u.AnswerId)
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(u => u.User)
                    .WithMany()
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(u => u.CommentAgreements)
            .WithMany(a => a.AgreeingUsers)
            .UsingEntity<CommentAgreement>(
                j => j.HasOne(u => u.Comment)
                    .WithMany()
                    .HasForeignKey(u => u.CommentId)
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(u => u.User)
                    .WithMany()
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(u => u.RatedPosts)
            .WithMany(a => a.RatingUsers)
            .UsingEntity<PostRating>(
                j => j.HasOne(u => u.Post)
                    .WithMany()
                    .HasForeignKey(u => u.PostId)
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(u => u.User)
                    .WithMany()
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(u => u.PostViews)
            .WithMany(a => a.ViewingUsers)
            .UsingEntity<PostView>(
                j => j.HasOne(u => u.Post)
                    .WithMany()
                    .HasForeignKey(u => u.PostId)
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(u => u.User)
                    .WithMany()
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
        builder.HasMany(u => u.QuestionAgreements)
            .WithMany(a => a.AgreeingUsers)
            .UsingEntity<QuestionAgreement>(
                j => j.HasOne(u => u.Question)
                    .WithMany()
                    .HasForeignKey(u => u.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(u => u.User)
                    .WithMany()
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
            
        builder.HasMany(u => u.SavedPosts)
            .WithMany(a => a.SavingUsers)
            .UsingEntity<UserSavedPost>(
                j => j.HasOne(u => u.Post)
                    .WithMany()
                    .HasForeignKey(u => u.PostId)
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne(u => u.User)
                    .WithMany()
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
            );
    }
}