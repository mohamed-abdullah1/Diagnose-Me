using MedicalBlog.Application.Common.Interfaces.Services;
using FileTypeChecker.Extensions;
using ErrorOr;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.Authentication.Helpers;


public class SaveFile
{
    public static ErrorOr<string> SavePicture(string Base64Picture, IFileHandler _fileHandler)
    {
        string pictureUrl= string.Empty;
        if (!string.IsNullOrEmpty(Base64Picture)){
            var picture = Convert.FromBase64String(Base64Picture);
            Stream pictureStreem = new MemoryStream(picture);
            if (!pictureStreem.IsImage())
                return (Errors.File.NotAPicture);
            
            if(picture.Length > ( 10 * 1024 ) && picture.Length < (5 * 1024 * 1024))
                return Errors.File.SizeDoesNotMatch;
            
            var result = _fileHandler.SaveFile(picture);
            if (result.IsError)
                return (result.Errors);
            pictureUrl = result.Value;
        }
        return pictureUrl;
    }
}