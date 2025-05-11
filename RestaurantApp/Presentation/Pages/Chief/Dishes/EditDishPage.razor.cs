using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.FileStorage;

namespace RestaurantApp.Presentation.Pages.Chief.Dishes;

public partial class EditDishPage
{
    [Parameter] public int Id { get; set; }

    private bool IsAutoCalculateWeight { get; set; }
    private DishDto DishDto { get; set; } = new DishDto();
    private DishIngredientDto AddIngredientDto { get; set; } = new DishIngredientDto();

    private List<DishCategory> DishCategories { get; set; } = [];

    private IBrowserFile? File;

    private string? ImagePreviewUrl { get; set; }

    protected override async Task OnInitializedAsync()
    {
        DishDto = await DishService.GetByIdAsync(Id);
        ImagePreviewUrl = DishDto.ImageUrl;
        StateHasChanged();
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

    private async Task CreateDishAsync()
    {
        if (File != null)
        {
            var fileStorageService = new FileStorageService();
            fileStorageService.DeleteFile(DishDto.ImageUrl);
            DishDto.ImageUrl = await fileStorageService.SaveFileAsync(File);
        }

        await DishService.UpdateAsync(DishDto);

        NavigationManager.NavigateTo("/chief/dishes");
    }

    private void CancelEdit()
    {
        NavigationManager.NavigateTo("/chief/dishes");
    }

    private async Task<IEnumerable<CategoryBase>> SearchDishType(string value, CancellationToken token)
    {
        if (string.IsNullOrEmpty(value))
        {
            return DishCategories;
        }

        return DishCategories.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }
}