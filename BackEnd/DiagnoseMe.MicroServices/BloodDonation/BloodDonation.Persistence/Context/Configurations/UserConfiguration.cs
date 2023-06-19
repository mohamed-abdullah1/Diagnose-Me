using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BloodDonation.Persistence.Context.Configurations;

public class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder=null!)
    {
        builder.ToTable("Users");
        base.Configure(builder);
        builder.Property(c => c.Name).IsRequired();  
        builder.Property(c => c.ProfilePictureUrl);
        builder.Property(c => c.FullName).IsRequired(); 
        builder.Property(c => c.BloodType).IsRequired();
        builder.Property(c => c.LastDonationDate);
    }
}