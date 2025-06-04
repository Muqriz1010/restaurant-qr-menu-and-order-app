using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var order = new Order
        {
            CreatedAt = DateTime.Now,
            TotalPrice = 100,
            MerchantId = orderDTO.MerchantId,
            OrderItems = (orderDTO.OrderItems ?? Enumerable.Empty<OrderItemDTO>()).Select(item => new OrderItem
            {
                ItemId = item.ItemId,
                Quantity = item.Quantity,
                OrderId = orderDTO.Id
            }).ToList()
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return Ok("Order created successfully.");
    }

}