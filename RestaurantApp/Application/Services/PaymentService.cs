
using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Payment> CreatePaymentAsync(PaymentCreating payment)
    {
        var model = new Payment(
            payment.OrderId,
            payment.AmountPaid,
            payment.PaymentDate);

        await _paymentRepository.AddPaymentAsync(model);

        return model;
    }

    public async Task<List<Payment>> GetAllPaymentsAsync()
    {
        return await _paymentRepository.GetAllPaymentsAsync();
    }

    public async Task<Payment?> GetPaymentByOrderIdAsync(int orderId)
    {
        return await _paymentRepository.GetPaymentByOrderIdAsync(orderId);
    }
}