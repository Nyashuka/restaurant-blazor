using MudBlazor;

using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Services;

namespace RestaurantApp.Presentation.Pages.Orders;

public partial class OrdersPage
{
    public List<Order> Orders { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        await LoadOrders();
    }

    private async Task LoadOrders()
    {
        var authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        if(authenticationState == null || authenticationState?.User == null)
            return;

        string? userIdString = authenticationState.GetUserId();
        if (string.IsNullOrEmpty(userIdString))
            return;

        Orders = await OrderService.GetByUserIdAsync(Convert.ToInt32(userIdString));
    }

    private async Task OpenDetailsDialog(Order order)
    {
        var parameters = new DialogParameters<OrderDetailsDialog>
            {
                { x => x.Order, order },
            };

        var result = await DialogFactory.CreateAsync<OrderDetailsDialog>(parameters);
    }

    private async Task PayForOrder(Order order)
    {
        PaymentCreating payment = new(order.Id, order.Cost, DateTime.Now);
        await PaymentService.CreatePaymentAsync(payment);

        await LoadOrders();
    }

    private void EditOrder(int orderId)
    {
        NavigationManager.NavigateTo("/orders/edit/" + orderId);
    }
}