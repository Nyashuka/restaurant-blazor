using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.FileStorage;

namespace RestaurantApp.Presentation.Pages.Chief.Drinks;

public partial class EditDrinkPage
{
    [Parameter] public int Id { get; set; }

    private bool IsAutoCalculateWeight { get; set; }
    private DrinkDto DrinkDto { get; set; } = new DrinkDto();

    private List<DrinkCategory> DrinkCategories { get; set; } = [];

    private IBrowserFile? File;

    private string? ImagePreviewUrl { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DrinkDto = await DrinkService.GetByIdAsync(Id);
        ImagePreviewUrl = DrinkDto.ImageUrl;
        StateHasChanged();
    }

    private void CancelEdit()
    {
        NavigationManager.NavigateTo("/chief/drinks");
    }

    private async Task UploadFiles(IBrowserFile file)
    {
        var stream = file.OpenReadStream(long.MaxValue);
        await using (MemoryStream memoryStream = new())
        {
            await stream.CopyToAsync(memoryStream);

            var base64String = Convert.ToBase64String(memoryStream.ToArray());
            ImagePreviewUrl = $"data:{file.ContentType};base64,{base64String}";
        }

        File = file;

        StateHasChanged();
    }

    private void OnAddIngredientClicked()
    {
        StateHasChanged();
    }

    private async Task SaveDrinkAsync()
    {
        if (File != null)
        {
            var fileStorageService = new FileStorageService();
            fileStorageService.DeleteFile(DrinkDto.ImageUrl);
            DrinkDto.ImageUrl = await fileStorageService.SaveFileAsync(File);
        }

        await DrinkService.UpdateAsync(DrinkDto);

        NavigationManager.NavigateTo("/chief/dishes", true);
    }

    private async Task<IEnumerable<CategoryBase>> SearchDrinkCategory(string value, CancellationToken token)
    {
        if (string.IsNullOrEmpty(value))
        {
            return DrinkCategories;
        }

        return DrinkCategories.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }
}