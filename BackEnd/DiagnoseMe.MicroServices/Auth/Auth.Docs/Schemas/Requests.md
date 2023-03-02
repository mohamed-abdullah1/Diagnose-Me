## Schema 

--
### Note that those are request body only does not involve the query params
--

### AddUserToRoleRequest
```
{
    string UserName
}
```

### ChangeEmailRequest
```
{
    string NewEmail
}
```

### ChangeNameRequest
```
{
    string NewName
}
```

### ChangePasswordRequest
```
{
    string OldPassword,
    string NewPassword
}
```

### ConfirmEmailChangeRequest
```
{
    string Id,
    string NewEmail
}
```

### ConfirmEmailRequest
```
{
    string Id
}
```

### ForgotPasswordRequest
```
{
    string Email
}
```

### LoginRequest
```
{
    string Email,
    string Password
}
```

### RegisterRequest
```
{
    string FirstName,
    string LastName,
    string UserName,
    string NationalID,
    string Gender,
    string DateOfbirth,
    string BloodType,
    string Email,
    string Password
}
```

### RemoveUserToRoleRequest
```
{
    string UserName
}
```

### ResendEmailConfirmationRequest
```
{
    string Email
}
```

### ResetPasswordRequest
```
{
    string Id,
    string NewPassword
}
```

### UploadProfilePictureRequest
```
{
    string Base64EncodedFile
}
```

### VerifyDoctorIdentityRequest
```
{
    string Base64License
}
```

### VerifyPinRequest
```
{
    string PinCode
}
```