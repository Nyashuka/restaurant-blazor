using RestaurantApp.Domain.Models;
using RestaurantApp.Domain.Enums;
using MudBlazor;
using RestaurantApp.Presentation.Dialogs;

namespace RestaurantApp.Presentation.Pages.ManagerPages;

public partial class ManageOrdersPage
{
    public List<Order> Orders { get; set; } = [];
    private Dictionary<OrderStatusEnum, string> OrderStatuses = new()
    {
        { OrderStatusEnum.Created, "Потрібно підтвердити" },
        { OrderStatusEnum.AwaitingPayment, "Очікує на оплату" },
        { OrderStatusEnum.Confirmed, "Підтверджено" },
        { OrderStatusEnum.Completed, "Завершено" },
        { OrderStatusEnum.Canceled, "Відмінено" },
    };
    private KeyValuePair<OrderStatusEnum, string> SelectedOrderStatus { get; set; } =
        new KeyValuePair<OrderStatusEnum, string>(OrderStatusEnum.Created, "");

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

    public async Task OnCompleteOrderClicked(Order order)
    {
        var result = await DialogFactory.CreateAsync<ConfirmationDialog>();

        if (result?.Canceled == false)
        {
            await OrderService.CompleteOrderAsync(order.Id);
            Orders = await OrderService.GetByStatusAsync(SelectedOrderStatus.Key);
            StateHasChanged();
        }
    }

    private async Task OnDeclineOrderClicked(Order order)
    {
        await OrderService.DeclineOrderAsync(order.Id);
        Orders = await OrderService.GetByStatusAsync(SelectedOrderStatus.Key);
        StateHasChanged();
    }

    public async Task OnSelectedStatus(KeyValuePair<OrderStatusEnum, string> status)
    {
        SelectedOrderStatus = status;
        Orders = await OrderService.GetByStatusAsync(SelectedOrderStatus.Key);
    }

    public async Task<IEnumerable<KeyValuePair<OrderStatusEnum, string>>> SearchOrderStatus(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        return OrderStatuses;
    }
}