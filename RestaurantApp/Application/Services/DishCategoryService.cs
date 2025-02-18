using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Application.Services;

public class DishCategoryService : IDishCategoryService
{
    private readonly IDishCategoryRepository _dishCategoryRepository;

    public DishCategoryService(IDishCategoryRepository dishTypeRepository)
    {
        _dishCategoryRepository = dishTypeRepository;
    }

    public async Task CreateAsync(CreateDishTypeDto createDishTypeDto)
    {
        var model = new DishCategory(0, createDishTypeDto.Name, createDishTypeDto.IsShared);

        await _dishCategoryRepository.AddAsync(model);
    }

    public async Task<List<DishCategory>> GetAllAsync()
    {
        return await _dishCategoryRepository.GetAllAsync();
    }

    public async Task RemoveAsync(int id)
    {
        if(await _dishCategoryRepository.GetByIdAsync(id) is DishCategory dishType)
            await _dishCategoryRepository.RemoveAsync(dishType);
    }
}
