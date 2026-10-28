using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities;

public class InvoiceLine : BaseEntity<Guid>, IAuditableEntity
{
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public int Days { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

}