
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class MerchantController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MerchantController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("api/merchants")]
    [Authorize]
    public async Task<IActionResult> CreateMerchant([FromBody] Merchant merchant)
    {
        if (merchant == null || string.IsNullOrEmpty(merchant.Name))
        {
            return BadRequest("Invalid merchant data.");
        }

        _context.Merchants.Add(merchant);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMerchant), new { pid = merchant.Id }, merchant);
    }

    [HttpGet]
    [Route("api/merchants/{id}")]
    public async Task<IActionResult> GetMerchant(int id)
    {
        var merchant = await _context.Merchants.FindAsync(id);
        if (merchant == null)
        {
            return NotFound();
        }

        return Ok(merchant);
    }
}