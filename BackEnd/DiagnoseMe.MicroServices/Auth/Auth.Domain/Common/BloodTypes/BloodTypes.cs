using System.Collections.Generic;
namespace Auth.Domain.Common.BloodTypes;

public static class BloodTypes
{
    public const string APositive = "A+";
    public const string ANegative = "A-";
    public const string BPositive = "B+";
    public const string BNegative = "B-";
    public const string ABPositive = "AB+";
    public const string ABNegative = "AB-";
    public const string OPositive = "O+";
    public const string ONegative = "O-";
    public const string IDoNotKnow = "I do not know";
    public static List<string> bloodTypeList => new List<string>{ 
        APositive,
        ANegative,
        BPositive,
        BNegative,
        ABPositive,
        ABNegative,
        OPositive,
        ONegative,
        IDoNotKnow 
        };

}