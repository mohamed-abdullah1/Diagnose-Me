using FileTypeChecker.Extensions;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;

namespace Auth.Application.Authentication.Helpers;


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
}