using System.Drawing;
using System.Drawing.Imaging;
using ErrorOr;
using FileTypeChecker.Extensions;
using MedicalServices.Domain.Common.Errors;
using Microsoft.AspNetCore.Http;

namespace MedicalServices.Application.MedicalServices.Helpers;


public class FileConverter
{
    public static ErrorOr<IFormFile> ConvertToPng(string Base64Picture)
    {
        if (!string.IsNullOrEmpty(Base64Picture)){
            var picture = Convert.FromBase64String(Base64Picture);
            Stream pictureStream = new MemoryStream(picture);
            if (!pictureStream.IsImage())
                return (Errors.File.NotAPicture);
           
            Image image = Image.Load(pictureStream);
            MemoryStream pngStream = new MemoryStream();
            image.Save(pngStream, new SixLabors.ImageSharp.Formats.Png.PngEncoder());
            pngStream.Position = 0;
            
            return new FormFile(
                    pngStream,
                    0,
                    pngStream.Length,
                    null!,
                    new Guid().ToString() + ".png");
        }
        return Errors.File.NullOrEmpty;
        
    }

    // public static ErrorOr<string> SavePicture(string Base64Picture)
    // {
    //     string pictureUrl= string.Empty;
    //     if (!string.IsNullOrEmpty(Base64Picture)){
    //         var picture = Convert.FromBase64String(Base64Picture);
    //         Stream pictureStreem = new MemoryStream(picture);
    //         if (!pictureStreem.IsImage())
    //             return (Errors.File.NotAPicture);
    //         var result = _fileHandler.SaveFile(picture);
    //         if (result.IsError)
    //             return (result.Errors);
    //         pictureUrl = result.Value;
    //     }
    //     return pictureUrl;
    // }
}