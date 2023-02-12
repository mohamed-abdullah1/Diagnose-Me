using BloodDonation.Application.Common.Interfaces.Persistence;
using BloodDonation.Persistence.Context;

namespace BloodDonation.Persistence.Repositories;

public class DonationRequestRepository : BaseRepo<DonationRequest>, IDonationRequestRepository
{
    public DonationRequestRepository(DbContext context) : base(context)
    {
    }

    public async Task<List<DonationRequest>> GetByBloodType(string bloodType)
    {
        return await table
            .Where(c => c.BloodType == bloodType)
            .Include(c => c.Requester)
            .Include(c => c.DonnerDonationRequests)
            .ThenInclude(c => c.Donner)
            .ToListAsync();
    }

    public async Task<List<DonationRequest>> GetByRequesterId(string requesterId)
    {
        return await table
            .Where(c => c.RequesterId == requesterId)
            .Include(c => c.Requester)
            .Include(c => c.DonnerDonationRequests)
            .ThenInclude(c => c.Donner)
            .ToListAsync();
    }

    public async Task<List<DonationRequest>> GetByStatus(string status)
    {
        return await table
            .Where(c => c.Status == status)
            .Include(c => c.Requester)
            .Include(c => c.DonnerDonationRequests)
            .ThenInclude(c => c.Donner)
            .ToListAsync();
    }
}