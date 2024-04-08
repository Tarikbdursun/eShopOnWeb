using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Services;

namespace Microsoft.eShopWeb.Web.Controllers;

//[ApiExplorerSettings(IgnoreApi = true)]
//[Authorize] // Controllers that mainly require Authorization still use Controller/View; other pages use Pages
[Route("api/[controller]")]
[ApiController]
public class AdminController : Controller
{
    private readonly IOrderService _orderService;

    public AdminController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("list-orders")]
    public async Task<IActionResult> ListOrders()
    {
        try
        {
            var orders = await _orderService.List();
            return Ok(orders);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpPut("set-order-status/{orderId}")]
    public async Task<IActionResult> SetOrderStatus(int orderId, [FromBody] short status)
    {
        try
        {
            await _orderService.SetOrderStatus(orderId, status);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
