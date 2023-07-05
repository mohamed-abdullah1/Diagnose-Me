namespace MedicalServices.Domain.Common.FIles;

public static class AllowedFileTypes
{
    public const string Image = "image";
    public const string Doc = "doc";
    public static List<string> AllowedTypes = new()
    {
        Image,
        Doc};
}