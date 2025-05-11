using Microsoft.AspNetCore.Components.Forms;

using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.FileStorage;

namespace RestaurantApp.Presentation.Pages.Chief.Drinks
{
    public partial class CreateDrinkPage
    {
        private DrinkCreatingDto DrinkCreatingDto { get; set; } = new();
        private List<DrinkCategory> DrinkCategories { get; set; } = [];

        private IBrowserFile? File;

        private string? ImagePreviewUrl { get; set; }


        protected override async Task OnInitializedAsync()
        {
            DrinkCategories = await DrinkCategoryService.GetAllAsync();
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

        private async Task CreateDrinkAsync()
        {
            if(File != null)
            {
                DrinkCreatingDto.ImageUrl = await new FileStorageService().SaveFileAsync(File);
            }

            await DrinkService.CreateAsync(DrinkCreatingDto);

            NavigationManager.NavigateTo("/chief/drinks", true);
        }

        private async Task<IEnumerable<DrinkCategory>> SearchDrinkCategory(string value, CancellationToken token)
        {
            if (string.IsNullOrEmpty(value))
            {
                return DrinkCategories;
            }

            return DrinkCategories.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}