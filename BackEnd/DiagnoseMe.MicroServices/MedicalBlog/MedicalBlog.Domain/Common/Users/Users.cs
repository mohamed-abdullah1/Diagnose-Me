namespace MedicalBlog.Domain.Common.Users;

public static class Users
{
    public const string Admin = "Admin";
    public static string AdminId = GuidHelper.GenerateGuidForString(Admin);
    public const string Patient = "Patient";
    public static string PatientId = GuidHelper.GenerateGuidForString(Patient);
    public const string Doctor = "Doctor";
    public static string DoctorId = GuidHelper.GenerateGuidForString(Doctor);
}