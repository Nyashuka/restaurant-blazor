using Microsoft.AspNetCore.Components.Forms;

namespace RestaurantApp.Infrastructure.FileStorage;

public interface IFileStorageService
{
    Task<string> SaveFileAsync(IBrowserFile file);
    Task<byte[]> GetFileAsync(string filePath);
    void DeleteFile(string filePath);
}