using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BloodDonation.Persistence.Context.Configurations;

public class DonationRequestConfiguration : BaseConfiguration<DonationRequest>
{
    public override void Configure(EntityTypeBuilder<DonationRequest> builder=null!)
    {
        builder.ToTable("DonationRequests");
        base.Configure(builder);
        builder.Property(c => c.BloodType).IsRequired();  
        builder.Property(c => c.Hospital).IsRequired();
        builder.Property(c => c.Reason).IsRequired(); 
        builder.Property(c => c.Status).IsRequired(); 
        builder.Property(c => c.UserId).IsRequired();
        builder.Property(c => c.DonatorUserId); 
        builder.HasOne(c => c.User).WithMany(c => c.DonationRequests).HasForeignKey(c => c.UserId);
        builder.HasOne(c => c.DonatorUser).WithMany(c => c.Donations).HasForeignKey(c => c.DonatorUserId);
    }
}