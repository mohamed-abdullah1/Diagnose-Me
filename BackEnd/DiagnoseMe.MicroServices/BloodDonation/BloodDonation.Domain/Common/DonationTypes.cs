namespace BloodDonation.Domain.Common;

public static class DonationTypes
{
    public const string Blood = "Blood";
    public const string Plasma = "Plasma";
    public const string Platelets = "Platelets";
    public const string BoneMarrow = "BoneMarrow";
    public const string Organ = "Organ";
    public const string Tissue = "Tissue";
    public const string UmbilicalCordBlood = "UmbilicalCordBlood";

    public static List<string> All => new List<string>
    {
        Blood,
        Plasma,
        Platelets
        // ,
        // BoneMarrow,
        // Organ,
        // Tissue,
        // UmbilicalCordBlood
    };
    
}   
