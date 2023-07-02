using BloodDonation.Application.Common.Interfaces.Persistence;

namespace BloodDonation.Persistence.Repositories;

public class DonnerDonationRequestRepository : BaseRepo<DonnerDonationRequest>, IDonnerDonationRequestRepository
{
    public DonnerDonationRequestRepository(DbContext context) : base(context)
    {
    }
}