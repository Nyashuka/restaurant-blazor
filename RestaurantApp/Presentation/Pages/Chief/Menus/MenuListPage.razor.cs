namespace RestaurantApp.Presentation.Pages.Chief.Menus;

using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dialogs;

public partial class MenuListPage
{
    private List<Menu> MenuList { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        MenuList = await MenuService.GetAllAsync();
    }

    public void OnEditClicked(int id)
    {
        NavigationManger.NavigateTo("/chief/menu/edit/" + id);
    }

    public async Task OnDeleteClicked(int id)
    {
        var result = await DialogFactory.CreateAsync<ConfirmationDialog>();

        if (result?.Canceled == false)
        {
            await MenuService.RemoveAsync(id);

            MenuList = await MenuService.GetAllAsync();
            StateHasChanged();
        }
    }
}