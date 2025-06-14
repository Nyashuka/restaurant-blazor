using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Dtos.Editing;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Application.Services;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepository;
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuService(IMenuRepository menuRepository, IMenuItemRepository menuItemRepository)
    {
        _menuRepository = menuRepository;
        _menuItemRepository = menuItemRepository;
    }

    public async Task CreateAsync(CreateMenuDto createMenuDto)
    {
        Menu menu = new Menu(
            createMenuDto.Name,
            createMenuDto.EventType.Id,
            createMenuDto.ImageUrl
        );

        await _menuRepository.AddAsync(menu);

        var menuItems = new List<MenuItem>();
        foreach (var item in createMenuDto.Dishes)
        {
            menuItems.Add(new MenuItem(menu.Id, item.Id));
        }
        foreach (var item in createMenuDto.Drinks)
        {
            menuItems.Add(new MenuItem(menu.Id, item.Id));
        }

        await _menuItemRepository.AddRangeAsync(menuItems);
    }

    public async Task<List<Menu>> GetAllAsync()
    {
        return await _menuRepository.GetAllAsync();
    }

    public async Task<Menu?> GetByIdAsync(int id)
    {
        return await _menuRepository.GetByIdAsync(id);
    }

    public async Task<List<FoodItem>> GetFoodItemsByMenuId(int id)
    {
        return await _menuRepository.GetFoodItemsByMenuId(id);
    }

    public async Task<List<MenuItem>> GetMenuItemsByMenuId(int id)
    {
        return await _menuItemRepository.GetAllByMenuIdAsync(id);
    }

    public async Task RemoveAsync(int id)
    {
        if(await _menuRepository.GetByIdAsync(id) is Menu menu)
        {
            await _menuRepository.RemoveAsync(menu);
            return;
        }

        throw new Exception($"Menu for deletion with given id({id}) is not exists");
    }

    public async Task UpdateAsync(EditMenuDto menuEditingDto)
    {
        var menu = await _menuRepository.GetByIdAsync(menuEditingDto.Id);

        if(menu == null) return;

        menu.Update(menuEditingDto.Name,
                    menuEditingDto.EventTypeId,
                    menuEditingDto.ImageUrl);

        _menuRepository.UpdateAsync(menu);

        var oldMenuItems = await _menuItemRepository.GetAllByMenuIdAsync(menu.Id);
        foreach(var item in oldMenuItems)
        {
            await _menuItemRepository.RemoveAsync(item);
        }

        var menuItems = new List<MenuItem>();
        foreach (var item in menuEditingDto.Dishes)
        {
            menuItems.Add(new MenuItem(menu.Id, item.Id));
        }
        foreach (var item in menuEditingDto.Drinks)
        {
            menuItems.Add(new MenuItem(menu.Id, item.Id));
        }

        await _menuItemRepository.AddRangeAsync(menuItems);
    }
}