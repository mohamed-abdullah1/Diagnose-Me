namespace Auth.Application.Authentication.Common;

public record PageResponse(
    List<Object> Objects,
    int CurrentPage,
    bool IsNextPage
);