namespace BloodDonation.Application.BloodDonation.Common;

public record PageResponse(
    List<Object> Objects,
    int CurrentPage,
    bool IsNextPage
);