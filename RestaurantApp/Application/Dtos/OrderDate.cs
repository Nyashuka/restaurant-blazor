namespace RestaurantApp.Application.Dtos;

public class OrderDate
{
    public int Number { get; set; }
    public DateTime? Date { get; set; }

    public OrderDate(int number)
    {
        Number = number;
    }
}