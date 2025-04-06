using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Pages.Chief.Menus;

public partial class CreateMenuPage
{
    private CreateMenuDto CreateMenuDto { get; set;} = new CreateMenuDto();

    private List<Dish> AllDishes { get; set; }= [];
    private List<Drink> AllDrinks { get; set; }= [];
    private List<EventType> EventTypes { get; set; } = [];

    private Dish? SelectedDishToAdd { get; set; } = null;
    private Drink? SelectedDrinkToAdd { get; set; } = null;

    protected override async Task OnInitializedAsync()
    {
        EventTypes = await EventTypeService.GetAllAsync();
        AllDishes = await DishService.GetAllAsync();
        AllDrinks = await DrinkService.GetAllAsync();
    }

    private void OnAddDish()
    {
        if(SelectedDishToAdd == null)
            return;

        CreateMenuDto.Dishes.Add(SelectedDishToAdd);
        SelectedDishToAdd = null;
    }

    private void OnAddDrink()
    {
        if(SelectedDrinkToAdd == null)
            return;

        CreateMenuDto.Drinks.Add(SelectedDrinkToAdd);
        SelectedDrinkToAdd = null;
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