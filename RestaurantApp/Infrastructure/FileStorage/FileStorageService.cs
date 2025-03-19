
using Microsoft.AspNetCore.Components.Forms;

namespace RestaurantApp.Infrastructure.FileStorage;

public class FileStorageService : IFileStorageService
{
    public const string DefaultUploadFolder = "wwwroot/uploads/";

    public void DeleteFile(string filePath)
    {
        throw new NotImplementedException();
    }

    public Task<byte[]> GetFileAsync(string filePath)
    {
        throw new NotImplementedException();
    }

    public async Task<string> SaveFileAsync(IBrowserFile file)
    {
        if (!Directory.Exists(DefaultUploadFolder))
        {
            Directory.CreateDirectory(DefaultUploadFolder);
        }

        var name = Guid.NewGuid();
        var extension = Path.GetExtension(file.Name);
        var fileName = $"{name}{extension}";
        var filePath = Path.Combine(DefaultUploadFolder, fileName);

        var stream = file.OpenReadStream(long.MaxValue);
        await using MemoryStream memoryStream = new();
        await stream.CopyToAsync(memoryStream);

        await using FileStream fs = new(filePath, FileMode.Create);
        memoryStream.Position = 0;
        await memoryStream.CopyToAsync(fs);

        return filePath.Replace("wwwroot", "");
    }
}