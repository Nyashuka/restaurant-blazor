namespace RestaurantApp.Domain.Models;

public class Drink : FoodItem
{
    public Drink(
        string name,
        double pricePerUnit,
        int categoryId,
        int volume,
        int volumePerPerson,
        bool isAlcoholic,
        string imageUrl) : base(name, pricePerUnit, categoryId, imageUrl)
    {
        Volume = volume;
        VolumePerPerson = volumePerPerson;
        IsAlcoholic = isAlcoholic;
    }

    public int Volume { get; private set; }
    public int VolumePerPerson { get; private set; }
    public bool IsAlcoholic { get; private set; }

    public void Update(string name, int volume, int volumePerPerson, double price, CategoryBase category, string imageUrl)
    {
        Name = name;
        CategoryId = category.Id;
        Category = null;
        Volume = volume;
        VolumePerPerson = volumePerPerson;
        PricePerUnit = price;
        ImageUrl = imageUrl;
    }
}