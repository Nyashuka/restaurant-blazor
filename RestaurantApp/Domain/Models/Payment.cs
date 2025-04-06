namespace RestaurantApp.Domain.Models;

public class Payment
{
    public Payment(int orderId, double amountPaid, DateTime paymentDate)
    {
        OrderId = orderId;
        AmountPaid = amountPaid;
        PaymentDate = paymentDate;
    }

    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public Order? Order { get; private set; }
    public double AmountPaid { get; private set; }
    public DateTime PaymentDate { get; private set; }
}