using BloodDonation.Application.Common.Interfaces.Persistence;

namespace BloodDonation.Persistence.Repositories;

public class DonationRequestRepository : BaseRepo<DonationRequest>, IDonationRequestRepository
{
    public DonationRequestRepository(DbContext context) : base(context)
    {
    }

    
}