using Microsoft.AspNetCore.Mvc.RazorPages;

using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Pages.ManagerPages;

public partial class BudgetReporting 
{
    private List<Payment> Payments { get; set; } = new List<Payment>();

    protected override async Task OnInitializedAsync()
    {
        Payments = await PaymentService.GetAllPaymentsAsync();
    }

    public void DownloadReport()
    {
        NavigationManager.NavigateTo("api/download/budget-csv/", forceLoad: true);
    }
    
}