namespace RestaurantApp.Application.Dtos;

public class PaymentCreating
{
    public PaymentCreating(int orderId, double amountPaid, DateTime paymentDate)
    {
        OrderId = orderId;
        AmountPaid = amountPaid;
        PaymentDate = paymentDate;
    }

    public int OrderId { get; set; }
    public double AmountPaid { get; set; }
    public DateTime PaymentDate { get; set; }
}