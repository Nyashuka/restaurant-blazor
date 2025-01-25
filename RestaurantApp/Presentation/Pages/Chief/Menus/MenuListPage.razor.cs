namespace RestaurantApp.Presentation.Pages.Chief.Menus;

using RestaurantApp.Domain.Models;

public partial class MenuListPage
{
    private List<Menu> MenuList { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        MenuList = await MenuService.GetAllAsync();
    }
}