using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IDishSubcategoryRepository
{
    Task AddAsync(DishSubcategory dishType);
    Task RemoveAsync(DishSubcategory dishType);
    Task<List<DishSubcategory>> GetAllAsync();
    Task<DishSubcategory?> GetByIdAsync(int id);
}