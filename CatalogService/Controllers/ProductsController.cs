using CatalogService.Data;
using CatalogService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Controllers;

[ApiController]
[Route("api/[controller]")] // => "api/products"
public class ProductsController : ControllerBase
{
    private readonly CatalogDbContext _db;

    public ProductsController(CatalogDbContext db)
    {
        _db = db;
    }

    // GET /api/products
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        var products = await _db.Products
            .AsNoTracking()
            .ToListAsync();

        return Ok(products);
    }

    // GET /api/products/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _db.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
            return NotFound(); // 404

        return Ok(product); // 200
    }

    // DTO для создания товара
    public class CreateProductRequest
    {
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; } = default!;
    }

    // POST /api/products
    [HttpPost]
    public async Task<ActionResult<Product>> Create([FromBody] CreateProductRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest("Name is required");

        if (request.Price <= 0)
            return BadRequest("Price must be greater than zero");

        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            Category = request.Category
        };

        _db.Products.Add(product);
        await _db.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            product);
    }
}