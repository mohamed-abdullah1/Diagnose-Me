using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BloodDonation.Persistence.Context.Configurations;

public class DonationRequestConfiguration : BaseConfiguration<DonationRequest>
{
    public override void Configure(EntityTypeBuilder<DonationRequest> builder=null!)
    {
        builder.ToTable("DonationRequests");
        base.Configure(builder);
        builder.Property(c => c.BloodType).IsRequired();  
        builder.Property(c => c.Locatoin).IsRequired();
        builder.Property(c => c.Reason).IsRequired(); 
        builder.Property(c => c.Status).IsRequired(); 
        builder.Property(c => c.RequesterId).IsRequired();
        builder.Property(c => c.DonnerId); 
        builder.HasOne(c => c.Requester).WithMany(c => c.DonationRequests).HasForeignKey(c => c.RequesterId);
    }
}