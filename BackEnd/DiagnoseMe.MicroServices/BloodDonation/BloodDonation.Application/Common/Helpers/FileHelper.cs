using FileTypeChecker.Extensions;
using FileTypeChecker;
using ErrorOr;
using BloodDonation.Application.BloodDonation.Common;
using BloodDonation.Domain.Common.Errors;

namespace BloodDonation.Application.Common.Helpers;


public class FileHelper
{
    public static ErrorOr<RMQFileResponse> CheckImage(
        string Base64File,
        string FilePath)
    {
        if (!string.IsNullOrEmpty(Base64File)){
            var picture = Convert.FromBase64String(Base64File);
            var tempFilePath = Path.GetTempFileName();
            FileStream pictureStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.ReadWrite);
            pictureStream.Write(picture, 0, picture.Length);

            if (!pictureStream.IsImage())
                return (Errors.File.NotAPicture);

            var fileType = FileTypeValidator.GetFileType(pictureStream);
            
            pictureStream.Close();
            if (!string.IsNullOrEmpty(tempFilePath) && File.Exists(tempFilePath))
                File.Delete(tempFilePath);
            
            return new RMQFileResponse(
                FilePath: Path.Combine(FilePath, $"{Guid.NewGuid().ToString()}.{fileType.Extension}"),
                Base64File: Base64File);
        }
        return Errors.File.NullOrEmpty;
        
    }


    internal static ErrorOr<RMQFileResponse> CheckDOC(
        string Base64File,
        string FilePath)
    {
        throw new NotImplementedException();
    }
}