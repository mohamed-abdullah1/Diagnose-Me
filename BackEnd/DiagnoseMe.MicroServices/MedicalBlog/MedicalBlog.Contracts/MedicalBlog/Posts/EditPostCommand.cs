namespace MedicalBlog.Contracts.MedicalBlog.Posts;

public record EditPostRequest(
    string Title,
    string Content,
    List<string> Tags);