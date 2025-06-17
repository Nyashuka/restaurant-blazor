
using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Application.Services;

public class DrinkCategoryService : IDrinkCategoryService
{
    private readonly IDrinkCategoryRepository _drinkCategoryRepository;

    public DrinkCategoryService(IDrinkCategoryRepository drinkCategoryRepository)
    {
        _drinkCategoryRepository = drinkCategoryRepository;
    }

    public async Task CreateAsync(DrinkCategoryCreatingDto drinkCategoryCreatingDto)
    {
        var model = new DrinkCategory(drinkCategoryCreatingDto.Name, drinkCategoryCreatingDto.IsShared);

        await _drinkCategoryRepository.AddAsync(model);
    }

    public async Task DisableAsync(int id)
    {
        if(await _drinkCategoryRepository.GetByIdAsync(id) is DrinkCategory category)
        {
            category.Disable();

            await _drinkCategoryRepository.UpdateAsync(category);
        }
    }

    public async Task EnableAsync(int id)
    {
        if(await _drinkCategoryRepository.GetByIdAsync(id) is DrinkCategory category)
        {
            category.Enable();

            await _drinkCategoryRepository.UpdateAsync(category);
        }
    }

    public async Task<List<DrinkCategory>> GetAllAsync(bool getDisabled = false)
    {
        return await _drinkCategoryRepository.GetAllAsync(getDisabled);
    }

    public async Task RemoveAsync(int id)
    {
        if(await _drinkCategoryRepository.GetByIdAsync(id) is DrinkCategory category)
            await _drinkCategoryRepository.RemoveAsync(category);
    }

    public async Task UpdateAsync(int id, EditDrinkCategoryDto drinkCategory)
    {
        if(await _drinkCategoryRepository.GetByIdAsync(id) is DrinkCategory category)
        {
            category.Update(drinkCategory.Name);

            await _drinkCategoryRepository.UpdateAsync(category);
        }
    }
}