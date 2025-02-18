using RestaurantApp.Application.Dtos;
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
            0,
            createMenuDto.Name,
            createMenuDto.EventType.Id,
            null, null
        );

        await _menuRepository.AddAsync(menu);

        var menuItems = new List<MenuItem>();
        foreach (var item in createMenuDto.Dishes)
        {
            menuItems.Add(new MenuItem(0, menu.Id, null, item.Id, null));
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
}