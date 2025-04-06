namespace RestaurantApp.Domain.Enums;

public enum OrderStatusEnum
{
    Created = 1,
    AwaitingPayment = 2,
    Confirmed = 4,
    Completed = 5,
    Canceled = 6,
}