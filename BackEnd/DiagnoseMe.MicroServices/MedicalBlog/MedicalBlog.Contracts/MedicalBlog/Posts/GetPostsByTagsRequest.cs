namespace MedicalBlog.Contracts.MedicalBlog.Posts;

public record GetPostsByTagsRequest(
    int PageNumber,
    List<string> Tags);