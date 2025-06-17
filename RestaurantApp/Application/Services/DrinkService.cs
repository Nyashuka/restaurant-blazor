
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


    public async Task<List<Drink>> GetAllAsync(bool getDisabled = false)
    {
        return await _drinkRepository.GetAllAsync(getDisabled);
    }

    public async Task<List<Drink>> GetByCategoryAsync(int categoryId, bool getDisabled = false)
    {
        return await _drinkRepository.GetByCategoryAsync(categoryId, getDisabled);
    }

    public async Task<DrinkDto> GetByIdAsync(int id)
    {
        var drink = await _drinkRepository.GetByIdAsync(id) ?? throw new Exception($"Drink with id({id} does not exists)");

        return new DrinkDto()
        {
            Id = drink.Id,
            Name = drink.Name,
            Category = drink.Category,
            Volume = drink.Volume,
            VolumePerPerson = drink.VolumePerPerson,
            IsAlcoholic = drink.IsAlcoholic,
            PricePerUnit = drink.PricePerUnit,
            ImageUrl = drink.ImageUrl
        };
    }

    public async Task RemoveAsync(int id)
    {
        var drink = await _drinkRepository.GetByIdAsync(id) ?? throw new Exception("Drink IS NOT EXISTS");

        drink.Disable();

        await _drinkRepository.UpdateAsync(drink);
    }

    public async Task EnableAsync(int id)
    {
        var drink = await _drinkRepository.GetByIdAsync(id) ?? throw new Exception("Drink IS NOT EXISTS");

        drink.Enable();

        await _drinkRepository.UpdateAsync(drink);
    }

    public async Task UpdateAsync(DrinkDto drinkDto)
    {
        var drink = await _drinkRepository.GetByIdAsync(drinkDto.Id) ?? throw new Exception("Drink IS NOT EXISTS");

        drink.Update(drinkDto.Name, drinkDto.Volume, drinkDto.VolumePerPerson, drinkDto.PricePerUnit, drinkDto.Category, drinkDto.ImageUrl);

        await _drinkRepository.UpdateAsync(drink);
    }
}
