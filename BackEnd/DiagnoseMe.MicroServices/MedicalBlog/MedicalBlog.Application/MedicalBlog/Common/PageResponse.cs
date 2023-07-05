namespace MedicalBlog.Application.MedicalBlog.Common;

public record PageResponse(
    List<Object> Objects,
    int CurrentPage,
    bool IsNextPage
);