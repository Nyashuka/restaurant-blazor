using Microsoft.EntityFrameworkCore;

using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Application.Services;

public class DishSubcategoryService : IDishSubcategoryService
{
    private readonly IDishSubcategoryRepository _dishSubcategoryRepository;

    public DishSubcategoryService(IDishSubcategoryRepository dishSubcategoryRepository)
    {
        _dishSubcategoryRepository = dishSubcategoryRepository;
    }

    public async Task CreateAsync(CreateDishSubcategoryDto createDishSubcategoryDto)
    {
        var model = new DishSubcategory(
            createDishSubcategoryDto.Name,
            createDishSubcategoryDto.Category.Id,
            null
        );

        await _dishSubcategoryRepository.AddAsync(model);
    }

    public async Task RemoveAsync(int id)
    {
        if (await _dishSubcategoryRepository.GetByIdAsync(id) is DishSubcategory dishSubcategory)
        {
            await _dishSubcategoryRepository.RemoveAsync(dishSubcategory);
        }
    }

    public async Task<List<DishSubcategory>> GetAllAsync()
    {
        return await _dishSubcategoryRepository.GetAllAsync();
    }
}