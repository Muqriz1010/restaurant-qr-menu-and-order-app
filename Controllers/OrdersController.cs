using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
[Authorize]

public class OrdersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OrdersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderDTO orderDTO)
    {
        var merchantIdClaim = User.FindFirst("MerchantId")?.Value;

        if (String.IsNullOrEmpty(merchantIdClaim))
        {
            return Forbid("Merchant ID is required.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var order = new Order
        {
            CreatedAt = DateTime.Now,
            TotalPrice = 100,
            MerchantId = int.Parse(merchantIdClaim),
            OrderItems = (orderDTO.OrderItems ?? Enumerable.Empty<OrderItemDTO>()).Select(item => new OrderItem
            {
                ItemId = item.ItemId,
                Quantity = item.Quantity,
            }).ToList()
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return Ok("Order created successfully.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var merchantIdClaim = User.FindFirstValue("MerchantId");
        if (String.IsNullOrEmpty(merchantIdClaim))
        {
            return Forbid("Merchant ID is required.");
        }

        int merchantId = int.Parse(merchantIdClaim);

        var orders = await _context.Orders
            .Where(o => o.MerchantId == merchantId)
            .Include(o => o.OrderItems)
            .ToListAsync();

        var orderDTOs = orders.Select(o => new OrderResponseDTO
        {
            Id = o.Id,
            OrderUUID = o.OrderUUID,
            CreatedAt = o.CreatedAt,
            Status = o.Status,
            TotalPrice = o.TotalPrice,
            OrderItems = o.OrderItems?.Select(oi => new OrderItemDTO
            {
                Id = oi.Id,
                ItemId = oi.ItemId,
                Quantity = oi.Quantity
            }).ToList()
        }).ToList();

        return Ok(orderDTOs);
    }
}