namespace MedicalServices.Domain.Common.Regexes;


public static class Regexes
{
    public const string Time = @"^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$";
    public const string Base64Regex = @"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$";
}