using ErrorOr;
using FileTypeChecker.Extensions;
using MedicalBlog.Application.Common.Interfaces.Services;
using MedicalBlog.Domain.Common.Errors;

namespace MedicalBlog.Application.MedicalBlog.Helpers;


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
            var result = _fileHandler.SaveFile(picture);
            if (result.IsError)
                return (result.Errors);
            pictureUrl = result.Value;
        }
        return pictureUrl;
    }
}