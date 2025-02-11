using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Application.Services;

public class DishService : IDishService
{
    private readonly IDishRepository _dishRepository;
    private readonly IDishIngredientRepository _dishIngredientRepository;

    public DishService(IDishRepository dishRepository, IDishIngredientRepository dishIngredientRepository)
    {
        _dishRepository = dishRepository;
        _dishIngredientRepository = dishIngredientRepository;
    }

    public async Task CreateAsync(CreateDishDto createDishDto)
    {
        var model = new Dish(
            0,
            createDishDto.Name,
            createDishDto.DishType.Id,
            null,
            createDishDto.Weight,
            createDishDto.ServingPerUnit,
            createDishDto.PricePerUnit);

        await _dishRepository.AddAsync(model);

        var ingredients = new List<DishIngredient>();
        foreach(var ingredient in createDishDto.Ingredients)
        {
            ingredients.Add(new DishIngredient(
                0,
                model.Id,
                null,
                ingredient.Name,
                ingredient.Weight));
        }
        await _dishIngredientRepository.AddRangeAsync(ingredients);
    }

    public async Task<List<Dish>> GetAllAsync()
    {
        return await _dishRepository.GetAllAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var dish = await _dishRepository.GetByIdAsync(id) ?? throw new Exception("DISH IS NOT EXISTS");

        var ingredients = await _dishIngredientRepository.GetAllDishIngredientsAsync(id);

        await _dishIngredientRepository.RemoveRangeAsync(ingredients);
        await _dishRepository.RemoveAsync(dish);
    }
}