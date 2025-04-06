namespace RestaurantApp.Application.Dtos;

public class PaymentCreating
{
    public int OrderId { get; set; }
    public double AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }
}