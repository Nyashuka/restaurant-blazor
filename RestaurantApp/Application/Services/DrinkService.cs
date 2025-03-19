
using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Application.Services;

public class DrinkService : IDrinkService
{
    private readonly IDrinkRepository _drinkRepository;

    public DrinkService(IDrinkRepository drinkRepository)
    {
        _drinkRepository = drinkRepository;
    }

    public async Task CreateAsync(DrinkCreatingDto drinkCreatingDto)
    {
        var model = new Drink(
            drinkCreatingDto.Name,
            drinkCreatingDto.PricePerUnit,
            drinkCreatingDto.Category.Id,
            drinkCreatingDto.Volume,
            drinkCreatingDto.VolumePerPerson,
            drinkCreatingDto.IsAlcoholic,
            drinkCreatingDto.ImageUrl
            );

        await _drinkRepository.AddAsync(model);
    }

    public async Task<List<Drink>> GetAllAsync()
    {
        return await _drinkRepository.GetAllAsync();
    }

    public async Task<List<Drink>> GetByCategoryAsync(int categoryId)
    {
        return await _drinkRepository.GetByCategoryAsync(categoryId);
    }

    public async Task<Drink?> GetByIdAsync(int id)
    {
        return await _drinkRepository.GetByIdAsync(id);
    }

    public async Task RemoveAsync(int id)
    {
        var drink = await _drinkRepository.GetByIdAsync(id) ?? throw new Exception("Drink IS NOT EXISTS");

        await _drinkRepository.RemoveAsync(drink);
    }
}
