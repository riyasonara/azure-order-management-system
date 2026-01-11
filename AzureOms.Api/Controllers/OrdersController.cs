using AzureOMS.Application.DTOs.Orders;
using AzureOMS.Application.Interfaces;
using AzureOMS.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AzureOms.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // 📌 GET: api/orders
    [HttpGet("GetOrders")]
    public async Task<IActionResult> GetOrders(
    int page = 1,
    int pageSize = 10,
    OrderStatus? status = null)
    {
        var userId = GetUserId();
        var orders = await _orderService.GetOrdersAsync(
            userId, page, pageSize, status);

        return Ok(orders);
    }

    // 📌 POST: api/orders
    [HttpPost("CreateOrder")]
    public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
    {
        var userId = GetUserId();
        var order = await _orderService.CreateOrderService(userId, request.Amount);
        return Ok(order);
    }

    // 🔑 Extract logged-in user id from JWT
    private Guid GetUserId()
    {
        var userIdClaim =   
            User.FindFirst(ClaimTypes.NameIdentifier) ??
            User.FindFirst("sub"); // JWT subject claim

        return Guid.Parse(userIdClaim!.Value);
    }

    [HttpPut("{orderId}/status")]
    public async Task<IActionResult> UpdateOrderStatus(Guid orderId, [FromQuery] OrderStatus orderStatus)
    {
        await _orderService.UpdateOrderStatusAsync(orderId, orderStatus);
        return Ok("Order status updated");
    }
}
