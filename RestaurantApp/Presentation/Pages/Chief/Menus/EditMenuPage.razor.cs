using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using RestaurantApp.Application.Dtos.Editing;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.FileStorage;

namespace RestaurantApp.Presentation.Pages.Chief.Menus;

public partial class EditMenuPage
{
    [Parameter] public int Id { get; set; }

    public EditMenuDto MenuEditingDto { get; set; } = new();

    private List<Dish> AllDishes { get; set; } = [];
    private List<Drink> AllDrinks { get; set; }= [];
    private List<EventType> EventTypes { get; set; } = [];

    private Dish? SelectedDishToAdd { get; set; } = null;
    private Drink? SelectedDrinkToAdd { get; set; } = null;

    private IBrowserFile? File;

    private string? ImagePreviewUrl { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var menu = await MenuService.GetByIdAsync(Id) ?? throw new Exception("Menu is not found");

        MenuEditingDto = new EditMenuDto()
        {
            Id = menu.Id,
            Name = menu.Name,
            EventTypeId = menu.EventTypeId,
            EventType = menu.EventType,
            ImageUrl = menu.ImageUrl,
            Drinks = menu.MenuItems.Where(x => x.FoodItem is Drink).Select(x => x.FoodItem as Drink).ToList(),
            Dishes = menu.MenuItems.Where(x => x.FoodItem is Dish).Select(x => x.FoodItem as Dish).ToList(),
        };

        EventTypes = await EventTypeService.GetAllAsync();
        AllDishes = await DishService.GetAllAsync();
        AllDrinks = await DrinkService.GetAllAsync();

        StateHasChanged();
    }

    public async Task SaveChangesAsync()
    {
        if (File != null)
        {
            var fileStorageService = new FileStorageService();
            fileStorageService.DeleteFile(MenuEditingDto.ImageUrl);
            MenuEditingDto.ImageUrl = await fileStorageService.SaveFileAsync(File);
        }

        await MenuService.UpdateAsync(MenuEditingDto);

        NavigationManager.NavigateTo("/chief/menu", true);
    }

     private void OnAddDish()
    {
        if(SelectedDishToAdd == null)
            return;

        MenuEditingDto.Dishes.Add(SelectedDishToAdd);
        SelectedDishToAdd = null;
    }

    private void OnAddDrink()
    {
        if(SelectedDrinkToAdd == null)
            return;

        MenuEditingDto.Drinks.Add(SelectedDrinkToAdd);
        SelectedDrinkToAdd = null;
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

    private async Task<IEnumerable<Dish>> SearchDish(string value, CancellationToken token)
    {
        if (string.IsNullOrEmpty(value))
        {
            return AllDishes;
        }

        return AllDishes.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    private async Task<IEnumerable<Drink>> SearchDrink(string value, CancellationToken token)
    {
        if (string.IsNullOrEmpty(value))
        {
            return AllDrinks;
        }

        return AllDrinks.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<IEnumerable<EventType>> SearchEventType(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return EventTypes;

        return EventTypes.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }
}