namespace BloodDonation.Application.Common.Interfaces.Persistence;

public interface IDonationRequestRepository : IBaseRepo<DonationRequest>
{
    Task<List<DonationRequest>> GetByBloodType(string bloodType);
    Task<List<DonationRequest>> GetByRequesterId(string requesterId);
}