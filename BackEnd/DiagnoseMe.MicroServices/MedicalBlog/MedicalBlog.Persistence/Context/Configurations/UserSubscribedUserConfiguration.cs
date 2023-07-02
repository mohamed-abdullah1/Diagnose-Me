using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalBlog.Persistence.Context.Configurations;

public class UserSubscribedUserConfiguration : BaseConfiguration<UserSubscribedUser>
{
    public override void Configure(EntityTypeBuilder<UserSubscribedUser> builder)
    {
        builder.HasKey(x => new { x.SubscriberId, x.SubscribedUserId });
        builder.ToTable("UserSubscribedUsers");
        builder.Property(x => x.SubscriberId).IsRequired();
        builder.Property(x => x.SubscribedUserId).IsRequired();
    }
}