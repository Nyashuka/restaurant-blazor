using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Pages.Orders;

public partial class OrdersPage
{
    public List<Order> Orders { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        Orders = await OrderService.GetAllAsync();
    }

    private async Task PayForOrder(Order order)
    {
        
    }
}