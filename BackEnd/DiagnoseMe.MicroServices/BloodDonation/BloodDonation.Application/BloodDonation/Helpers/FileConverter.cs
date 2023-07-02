using ErrorOr;
using FileTypeChecker.Extensions;
using BloodDonation.Domain.Common.Errors;
using Microsoft.AspNetCore.Http;
using FileTypeChecker;


namespace BloodDonation.Application.BloodDonation.Helpers;


public class FileConverter
{
    public static ErrorOr<IFormFile> ConvertToPng(string Base64Picture)
    {
        if (!string.IsNullOrEmpty(Base64Picture)){
            var picture = Convert.FromBase64String(Base64Picture);
            var tempFilePath = Path.GetTempFileName();
            FileStream pictureStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.ReadWrite);
            pictureStream.Write(picture, 0, picture.Length);

            if (!pictureStream.IsImage())
                return (Errors.File.NotAPicture);

            var fileType = FileTypeValidator.GetFileType(pictureStream);
            
            var fileName = Guid.NewGuid().ToString() + $".{fileType.Extension}";

            var formFile = new FormFile(
                pictureStream,
                0,
                pictureStream.Length,
                null!,
                fileName
            )
            {
                Headers = new HeaderDictionary(),
                ContentType = $"application/{fileType.Extension}"
            };

            pictureStream.Close();
            if (!string.IsNullOrEmpty(tempFilePath) && File.Exists(tempFilePath))
                File.Delete(tempFilePath);
            
            return formFile;
        }
        return Errors.File.NullOrEmpty;
        
    }
}