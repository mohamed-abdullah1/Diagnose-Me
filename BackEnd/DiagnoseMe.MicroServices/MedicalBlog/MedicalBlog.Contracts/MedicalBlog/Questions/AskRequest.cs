namespace MedicalBlog.Contracts.MedicalBlog.Questions;

public record AskRequest(
    string QuestionString,
    List<string> Tags);