using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Services;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Pages.Chief.Dishes
{
    public partial class CreateDishPage
    {
        private bool IsAutoCalculateWeight { get; set; }
        private CreateDishDto DishDto { get; set; } = new CreateDishDto();
        private DishIngredientDto AddIngredientDto { get; set; } = new DishIngredientDto();

        private List<DishCategory> DishCategories { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            DishCategories = await DishCategoryService.GetAllAsync();
        }

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

            if(IsAutoCalculateWeight)
            {
                DishDto.Weight = DishDto.Ingredients.Sum(x => x.Weight);
            }

            StateHasChanged();
        }

        private async Task CreateDishAsync()
        {
            await DishService.CreateAsync(DishDto);

            NavigationManager.NavigateTo("/chief/dishes", true);
        }

        private async Task<IEnumerable<DishCategory>> SearchDishType(string value, CancellationToken token)
        {
            if(string.IsNullOrEmpty(value))
            {
                return DishCategories;
            }

            return DishCategories.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
