using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IPaymentRepository
{
    Task AddPaymentAsync(Payment payment);
    Task<List<Payment>> GetAllPaymentsAsync();
    Task<Payment?> GetPaymentByOrderIdAsync(int orderId);
}