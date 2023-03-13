namespace MedicalBlog.Contracts.MedicalBlog.Answers;

public record AddAnswerRequest(
    string PostId,
    string CommentId,
    string AnswerString);