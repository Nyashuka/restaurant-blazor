using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Services;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Pages.Chief.Menus;

public partial class CreateMenuPage
{
    private CreateMenuDto CreateMenuDto { get; set;} = new CreateMenuDto();

    private List<Dish> AllDishes { get; set; }= [];
    private List<EventType> EventTypes { get; set; } = [];

    private Dish? SelectedDishToAdd { get; set; } = null;

    protected override async Task OnInitializedAsync()
    {
        EventTypes = await EventTypeService.GetAllAsync();
        AllDishes = await DishService.GetAllAsync();
    }

    private void OnAddDish()
    {
        if(SelectedDishToAdd == null)
            return;

        CreateMenuDto.Dishes.Add(SelectedDishToAdd);
        SelectedDishToAdd = null;
    }

    private async Task CreateMenuAsync()
    {
        await MenuService.CreateAsync(CreateMenuDto);

        NavigationManager.NavigateTo("/chief/menu", true);
    }

    private async Task<IEnumerable<Dish>> SearchDish(string value, CancellationToken token)
    {
        if (string.IsNullOrEmpty(value))
        {
            return AllDishes;
        }

        return AllDishes.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<IEnumerable<EventType>> SearchEventType(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return EventTypes;

        return EventTypes.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }
}