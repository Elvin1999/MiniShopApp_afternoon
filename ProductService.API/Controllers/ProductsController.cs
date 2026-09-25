using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.API.Data;

namespace ProductService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductDbContext _context;

    public ProductsController(ProductDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _context.Products
            .ToListAsync();

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _context.Products
            .FindAsync(id);

        if (product is null)
            return NotFound("Product not found.");

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
            return BadRequest("Product name is required.");

        if (product.Price <= 0)
            return BadRequest("Price must be greater than zero.");

        if (product.Stock < 0)
            return BadRequest("Stock cannot be negative.");

        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            product);
    }

    [HttpPut("{id:int}/reduce-stock")]
    public async Task<IActionResult> ReduceStock(
        int id,
        ReduceStockRequest request)
    {
        if (request.Quantity <= 0)
            return BadRequest("Quantity must be greater than zero.");

        var product = await _context.Products
            .FindAsync(id);

        if (product is null)
            return NotFound("Product not found.");

        if (product.Stock < request.Quantity)
            return BadRequest("Not enough stock.");

        product.Stock -= request.Quantity;

        await _context.SaveChangesAsync();

        return Ok(product);
    }
}