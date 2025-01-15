using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IDishIngredientRepository
{
    Task AddAsync(DishIngredient dishIngredient);
    Task AddRangeAsync(List<DishIngredient> dishIngredients);
    Task RemoveAsync(DishIngredient dishIngredient);
    Task RemoveRangeAsync(List<DishIngredient> dishIngredients);
    Task<List<DishIngredient>> GetAllDishIngredientsAsync(int dishId);
    Task<DishIngredient?> GetByIdAsync(int id);
}