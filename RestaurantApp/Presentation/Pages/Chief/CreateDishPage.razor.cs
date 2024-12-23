using RestaurantApp.Presentation.Dtos;

namespace RestaurantApp.Presentation.Pages.Chief
{
    public partial class CreateDishPage
    {
        private AddDishDto DishDto { get; set; } = new AddDishDto();
        private DishIngredientDto AddIngredientDto { get; set; } = new DishIngredientDto();

        private void OnAddIngredientClicked()
        {
            DishDto.Ingredients.Add(new DishIngredientDto()
                {
                    Name = AddIngredientDto.Name,
                    Weight = AddIngredientDto.Weight
                }
            );

            AddIngredientDto.Name = string.Empty;
            AddIngredientDto.Weight = 0;

            StateHasChanged();
        }
    }
}
