using BloodDonation.Application.Common.Interfaces.Persistence;

namespace BloodDonation.Persistence.Repositories;

public class DonnerDonationRequestRepository : BaseRepo<DonnerDonationRequest>, IDonnerDonationRequestRepo
{
    public DonnerDonationRequestRepository(DbContext context) : base(context)
    {
    }
}