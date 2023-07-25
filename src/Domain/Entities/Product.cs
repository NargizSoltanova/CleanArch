using Domain.Common;

namespace practice.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
}
