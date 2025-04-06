
using Microsoft.EntityFrameworkCore;

using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly IDbContextFactory<RestaurantDbContext> _dbContextFactory;

    public PaymentRepository(IDbContextFactory<RestaurantDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task AddPaymentAsync(Payment payment)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        context.Payments.Add(payment);
        await context.SaveChangesAsync();
    }

    public async Task<List<Payment>> GetAllPaymentsAsync()
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.Payments
            .Include(x => x.Order)
            .ToListAsync();
    }

    public async Task<Payment?> GetPaymentByOrderIdAsync(int orderId)
    {
        await using var context = _dbContextFactory.CreateDbContext();

        return await context.Payments
            .SingleOrDefaultAsync(x => x.OrderId == orderId);
    }
}