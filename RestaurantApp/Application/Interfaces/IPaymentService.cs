using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IPaymentService
{
    Task CreatePaymentAsync(PaymentCreating payment);
    Task<List<Payment>> GetAllPaymentsAsync();
    Task<Payment?> GetPaymentByOrderIdAsync(int orderId);
}