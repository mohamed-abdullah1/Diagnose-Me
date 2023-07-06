using System.Collections.Generic;
namespace Auth.Domain.Common.Genders;

public static class Genders
{
    public const string Male = "Male";
    public const string Female = "Female";
    public static List<string> All = new List<string>{
        Male,
        Female
    };
}