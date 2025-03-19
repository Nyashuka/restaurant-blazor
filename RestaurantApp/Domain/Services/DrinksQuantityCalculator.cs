using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Domain.Services;

public class DrinksQuantityCalculator
{
    public async Task<List<SelectedFoodItem>> CalculateQuantity(int guestCount, List<SelectedFoodItem> drinks)
    {
        // key - category id, value = list of dishes in this category
        Dictionary<int, List<SelectedFoodItem>> categorizedItems = [];

        // групуємо по категоріям обрані страви
        foreach (var selectedDrink in drinks)
        {
            if(selectedDrink.Item is Drink drink)
            {
                if(categorizedItems.TryGetValue(drink.DrinkCategory.Id, out var itemsByCategory))
                {
                    itemsByCategory.Add(selectedDrink);
                }
                else
                {
                    categorizedItems.TryAdd(drink.DrinkCategoryId, [ selectedDrink ]);
                }
            }
        }

        List<SelectedFoodItem> recalculatedItemsCount = [];

        foreach(var categoryList in categorizedItems)
        {
            int itemsCountInCategory = categoryList.Value.Count;
            bool isShared = ((Drink)categoryList.Value.First().Item).DrinkCategory.IsShared;

            foreach (var selectedItem in categoryList.Value)
            {
                if(selectedItem.Item is Drink drink)
                {
                    if (isShared)
                    {
                        int amountPeopleCanServePortion = drink.Volume / drink.VolumePerPerson;

                        int portionNeeded = guestCount > amountPeopleCanServePortion ?
                            guestCount / amountPeopleCanServePortion :
                            1;

                        selectedItem.Count = portionNeeded > itemsCountInCategory ?
                            portionNeeded / itemsCountInCategory :
                            1;
                    }
                    else
                    {
                        selectedItem.Count = guestCount;
                    }

                    recalculatedItemsCount.Add(selectedItem);
                }
            }
        }

        return recalculatedItemsCount;
    }

}