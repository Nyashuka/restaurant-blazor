using RestaurantApp.Domain.Models;
using RestaurantApp.Domain.Enums;
using MudBlazor;
using RestaurantApp.Presentation.Dialogs;

namespace RestaurantApp.Presentation.Pages.ManagerPages;

public partial class ManageOrdersPage
{
    public List<Order> Orders { get; set; } = [];
    private OrderStatusEnum[] OrderStatuses { get; } = (OrderStatusEnum[])Enum.GetValues(typeof(OrderStatusEnum));
    private OrderStatusEnum SelectedOrderStatus { get; set; } = OrderStatusEnum.Created;

    protected override async Task OnInitializedAsync()
    {
        await OnSelectedStatus(SelectedOrderStatus);
    }

    private async Task OnConfirmOrderClicked(Order order)
    {
        if(order.Status == OrderStatusEnum.Created)
        {
            var crossingOrders = await OrderService.GetCrossedOrdersAsync(order.Id);

            var parameters = new DialogParameters<ApproveOrderDialog>
            {
                { x => x.OrderForApprove, order },
                { x => x.CrossingOrders, crossingOrders },
            };

            var result = await DialogFactory.CreateAsync<ApproveOrderDialog>(parameters);

            if (result?.Canceled == true)
            {
                return;
            }

            await OrderService.ApproveOrderAsync(order.Id);

            Orders.RemoveAll(x => crossingOrders.Any(y => y.Id == x.Id));
            Orders.Remove(order);
        }
        else
        {
            var result = await DialogFactory.CreateAsync<ConfirmOrderDialog>();

            if (result?.Canceled == false)
            {
                // await DishCategoryService.RemoveAsync(dishType.Id);
                Orders.Remove(order);
            }
        }

        StateHasChanged();
    }

    private async Task OnDeclineOrderClicked(Order order)
    {

    }

    public async Task OnSelectedStatus(OrderStatusEnum status)
    {
        SelectedOrderStatus = status;
        Orders = await OrderService.GetByStatusAsync(status);
    }

    public async Task<IEnumerable<OrderStatusEnum>> SearchOrderStatus(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        return OrderStatuses;
    }
}