## Schema 

### CommandResponse
```
{
    bool Success,
    string Message,
    string Path
}
```

### DonationResponse
```
{
    UserResponse Requester,
    List<DonnerDonationResponse> DonnerDonationResponses,
    string Id,
    string BloodType,
    string Locatoin,
    string Reason,
    string Status
}
```

### DonnerDonationResponse
```
{
    UserResponse Donner,
    string Status
}
```

### UserResponse
```
{
    string Id,
    string FullName,
    string ProfilePictureUrl,
    string BloodType
}
```