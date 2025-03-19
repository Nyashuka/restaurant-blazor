namespace RestaurantApp.Domain.Models;

public class Drink : FoodItem
{
    public Drink(
        string name,
        double pricePerUnit,
        int drinkCategoryId,
        int volume,
        int volumePerPerson,
        bool isAlcoholic,
        string imageUrl) : base(name, pricePerUnit, imageUrl)
    {
        DrinkCategoryId = drinkCategoryId;
        Volume = volume;
        VolumePerPerson = volumePerPerson;
        IsAlcoholic = isAlcoholic;
    }

    public int DrinkCategoryId { get; private set; }
    public int Volume { get; private set; }
    public int VolumePerPerson { get; private set; }
    public bool IsAlcoholic { get; private set; }

    public DrinkCategory DrinkCategory { get; private set; }
}