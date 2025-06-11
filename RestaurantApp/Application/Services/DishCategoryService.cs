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
        var model = new DishCategory(createDishTypeDto.Name, createDishTypeDto.IsShared);

        await _dishCategoryRepository.AddAsync(model);
    }

    public async Task DisableAsync(int id)
    {
        if(await _dishCategoryRepository.GetByIdAsync(id) is DishCategory category)
        {
            category.Disable();

            await _dishCategoryRepository.UpdateAsync(category);
        }
    }

    public async Task EnableAsync(int id)
    {
        if(await _dishCategoryRepository.GetByIdAsync(id) is DishCategory category)
        {
            category.Enable();

            await _dishCategoryRepository.UpdateAsync(category);
        }
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

    public async Task UpdateAsync(int id, EditDishCategoryDto dto)
    {
        if(await _dishCategoryRepository.GetByIdAsync(id) is DishCategory dishType)
        {
            dishType.Update(dto.Name);
            await _dishCategoryRepository.UpdateAsync(dishType);
        }
    }
}
