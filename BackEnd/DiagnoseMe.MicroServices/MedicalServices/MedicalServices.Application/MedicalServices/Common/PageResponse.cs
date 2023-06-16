
namespace MedicalServices.Application.MedicalServices.Common;


public record PageResponse(
    List<Object> Objects,
    int CurrentPage,
    bool IsNextPage
);