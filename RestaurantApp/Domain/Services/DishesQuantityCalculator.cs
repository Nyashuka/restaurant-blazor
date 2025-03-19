using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Domain.Services;

public class DishesQuantityCalculator
{
    public async Task<List<SelectedFoodItem>> CalculateQuantity(int guestCount, List<SelectedFoodItem> dishes)
    {
        Dictionary<int, List<SelectedFoodItem>> categorizedItems = [];

        // групуємо по категоріям обрані страви
        foreach (var selectedItem in dishes)
        {
            if(selectedItem.Item is Dish dish)
            {
                if(categorizedItems.TryGetValue(dish.DishCategoryId, out var itemsByCategory))
                {
                    itemsByCategory.Add(selectedItem);
                }
                else
                {
                    categorizedItems.TryAdd(dish.DishCategoryId, [ selectedItem ]);
                }
            }
        }

        List<SelectedFoodItem> recalculatedItemsCount = [];

        foreach(var categoryList in categorizedItems)
        {
            int itemsCountInCategory = categoryList.Value.Count;
            bool isShared = ((Dish)categoryList.Value.First().Item).DishCategory.IsShared;

            foreach (var selectedItem in categoryList.Value)
            {
                if(selectedItem.Item is Dish dish)
                {
                    if (isShared)
                    {
                        int amountPeopleCanServePortion = dish.Weight / dish.RecommendedWeightPerPortion;

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