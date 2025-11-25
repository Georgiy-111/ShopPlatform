namespace CatalogService.Domain.Entities;

public class Product
{
    public int Id { get; set; }          // PK
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; } = default!;
}