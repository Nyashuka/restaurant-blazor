
using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IOrderService _orderService;

    public PaymentService(IPaymentRepository paymentRepository, IOrderService orderService)
    {
        _paymentRepository = paymentRepository;
        _orderService = orderService;
    }

    public async Task CreatePaymentAsync(PaymentCreating payment)
    {
        var order = await _orderService.GetByIdAsync(payment.OrderId);

        if(order == null)
            return;

        var model = new Payment(
            payment.OrderId,
            payment.AmountPaid,
            payment.PaymentDate.ToUniversalTime());

        await _paymentRepository.AddPaymentAsync(model);

        await _orderService.PayForOrder(order.Id);
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