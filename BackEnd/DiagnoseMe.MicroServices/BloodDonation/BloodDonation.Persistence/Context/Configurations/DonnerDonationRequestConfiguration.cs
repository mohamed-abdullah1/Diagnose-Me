using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonation.Persistence.Context.Configurations;


public class DonnerDonationRequestConfiguration : BaseConfiguration<DonnerDonationRequest>
{
    public override void Configure(EntityTypeBuilder<DonnerDonationRequest> builder=null!)
    {
        builder.ToTable("DonnerDonationRequests");
        builder.HasKey(c => new {c.DonnerId, c.DonationRequestId});
        builder.Property(c => c.DonnerId).IsRequired();
        builder.Property(c => c.DonationRequestId).IsRequired();
        builder.Property(c => c.Status).IsRequired();
        builder.HasOne(c => c.Donner).WithMany(c => c.DonnerDonationRequests).HasForeignKey(c => c.DonnerId);
        builder.HasOne(c => c.DonationRequest).WithMany(c => c.DonnerDonationRequests).HasForeignKey(c => c.DonationRequestId);
    }
}