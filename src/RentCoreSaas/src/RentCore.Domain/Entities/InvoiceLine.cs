using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities;

public class InvoiceLine : BaseEntity<Guid>
{
    public string? Name { get; set; }
    public int Quantity { get; set; }
    public DateTime Days { get; set; }
    public decimal UnitPrice { get; private set; }
    public decimal LineTotal => Quantity * UnitPrice;
}