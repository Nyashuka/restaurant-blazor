using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Application.Services;

public class DishTypeService : IDishTypeService
{
    private readonly IDishTypeRepository _dishTypeRepository;

    public DishTypeService(IDishTypeRepository dishTypeRepository)
    {
        _dishTypeRepository = dishTypeRepository;
    }

    public async Task CreateAsync(CreateDishTypeDto createDishTypeDto)
    {
        var model = new DishType(0, createDishTypeDto.Name);

        await _dishTypeRepository.AddAsync(model);
    }

    public async Task<List<DishType>> GetAllAsync()
    {
        return await _dishTypeRepository.GetAllAsync();
    }

    public async Task RemoveAsync(int id)
    {
        if(await _dishTypeRepository.GetByIdAsync(id) is DishType dishType)
            await _dishTypeRepository.RemoveAsync(dishType);
    }
}
