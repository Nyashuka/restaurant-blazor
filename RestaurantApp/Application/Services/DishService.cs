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
            createDishDto.Name,
            createDishDto.PricePerUnit,
            createDishDto.DishType.Id,
            createDishDto.Weight,
            createDishDto.RecommendedWeightPerPerson,
            createDishDto.ImageUrl
            );

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

    public async Task<List<Dish>> GetAllAsync(bool getDisabled = false)
    {
        return await _dishRepository.GetAllAsync(getDisabled);
    }

    public async Task<List<Dish>> GetByCategoryAsync(int categoryId)
    {
        return await _dishRepository.GetByCategoryAsync(categoryId);
    }

    public async Task<DishDto> GetByIdAsync(int id)
    {
        var model = await _dishRepository.GetByIdAsync(id) ?? throw new Exception($"Dish with id({id} does not exists)");

        return new DishDto()
        {
            Id = model.Id,
            Name = model.Name,
            PricePerUnit = model.PricePerUnit,
            Category = model.Category,
            Weight = model.Weight,
            RecommendedWeightPerPerson = model.RecommendedWeightPerPortion,
            ImageUrl = model.ImageUrl,
            Ingredients = model.Ingredients,
        };
    }

    public async Task RemoveAsync(int id)
    {
        var dish = await _dishRepository.GetByIdAsync(id) ?? throw new Exception("DISH IS NOT EXISTS");
        dish.Disable();
        // await RemoveIngredients(id);
        await _dishRepository.UpdateAsync(dish);
    }

    public async Task EnableAsync(int id)
    {
        var dish = await _dishRepository.GetByIdAsync(id) ?? throw new Exception("DISH IS NOT EXISTS");
        dish.Enable();
        await _dishRepository.UpdateAsync(dish);
    }

    public async Task RemoveIngredients(int dishId)
    {
        var ingredients = await _dishIngredientRepository.GetAllDishIngredientsAsync(dishId);

        await _dishIngredientRepository.RemoveRangeAsync(ingredients);
    }

    public async Task UpdateAsync(DishDto dishDto)
    {
        var dish = await _dishRepository.GetByIdAsync(dishDto.Id) ?? throw new Exception("DISH IS NOT EXISTS");

        dish.Update(dishDto.Name, dishDto.Category, dishDto.ImageUrl);

        await _dishRepository.UpdateAsync(dish);
    }
}