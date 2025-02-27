using RestaurantApp.Domain.Models;
using RestaurantApp.Domain.Enums;

namespace RestaurantApp.Presentation.Pages.ManagerPages;

public partial class ManageOrdersPage
{
    public List<Order> Orders { get; set; } = [];
    private OrderStatusEnum[] _orderStatuses = (OrderStatusEnum[])Enum.GetValues(typeof(OrderStatusEnum));
    private OrderStatusEnum SelectedOrderStatus { get; set; } = OrderStatusEnum.Processing;

    protected override async Task OnInitializedAsync()
    {
        Orders = (await OrderService.GetAllAsync()).Where(x => x.Status == SelectedOrderStatus).ToList();
    }

    public async Task OnSelectedStatus(OrderStatusEnum status) 
    {
        SelectedOrderStatus = status;
        Orders = (await OrderService.GetAllAsync()).Where(x => x.Status == SelectedOrderStatus).ToList();
    }

    public async Task<IEnumerable<OrderStatusEnum>> SearchOrderStatus(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        // if (string.IsNullOrEmpty(value))
        return _orderStatuses;

        // return _orderStatuses.Where(x => x.ToString().Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }
}