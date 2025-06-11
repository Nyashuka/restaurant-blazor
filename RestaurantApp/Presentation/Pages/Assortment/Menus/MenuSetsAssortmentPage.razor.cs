using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Pages.Assortment.Menus;

public partial class MenuSetsAssortmentPage
{
    public List<Menu> Menus { get; private set; } = [];
    private bool DrawerOpen { get; set; } = true;

    protected override async Task OnInitializedAsync()
    {
        Menus = await MenuService.GetAllAsync();
    }

    public async Task OnEventTypeSelected(EventType eventType)
    {
        Menus = (await MenuService.GetAllAsync()).Where(x => x.EventTypeId == eventType.Id).ToList();
    }
}