namespace MedicalBlog.Contracts.MedicalBlog.Posts;

public record CreatePostRequest(
    string Title,
    string Content,
    List<string> Tags,
    List<string> Base64Images);
