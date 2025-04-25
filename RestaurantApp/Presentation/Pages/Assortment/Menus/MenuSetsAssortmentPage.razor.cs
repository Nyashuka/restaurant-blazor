using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Pages.Assortment.Menus;

public partial class MenuSetsAssortmentPage
{
    public List<Menu> Menus { get; private set; } = [];

    protected override async Task OnInitializedAsync()
    {
        Menus = await MenuService.GetAllAsync();
    }
}