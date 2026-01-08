using Microsoft.AspNetCore.Mvc;

namespace AzureOms.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetOrders()
    {
        return Ok("Orders list");
    }

    [HttpPost]
    public IActionResult CreateOrder()
    {
        return Ok("Order created");
    }
}
