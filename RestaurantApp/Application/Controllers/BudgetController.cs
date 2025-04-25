using System.Text;

using Microsoft.AspNetCore.Mvc;

using RestaurantApp.Application.Interfaces;

namespace RestaurantApp.Application.Controllers;

[Route("api/download")]
public class BudgetController : ControllerBase
{
    private readonly IPaymentService  _paymentService;
    
    public BudgetController(IPaymentService paymentService)
    {
        _paymentService = paymentService; 
    }

    [HttpGet("budget-csv")]
    public async Task<IActionResult> GetCsv()
    {
        var payments = await _paymentService.GetAllPaymentsAsync(); 
        
        var csv = new StringBuilder();
        csv.AppendLine("id,order-id,date,paid-amount");
        foreach (var payment in payments)
        {
            csv.AppendLine($"{payment.Id},{payment.OrderId},{payment.PaymentDate},{payment.AmountPaid}");
        }

        var bytes = Encoding.UTF8.GetBytes(csv.ToString());
        var stream = new MemoryStream(bytes);

        return File(stream, "text/csv", "data.csv");
    }
}