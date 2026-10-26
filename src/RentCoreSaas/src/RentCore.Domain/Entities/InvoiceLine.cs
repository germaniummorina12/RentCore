namespace RentCore.Domain.Entities;

public sealed class InvoiceLine : Abstractions.BaseEntity<Guid>
{
    public Guid InvoiceId { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal LineTotal => Quantity * UnitPrice;

    private InvoiceLine() { }

    internal static InvoiceLine Create(string description, int quantity, decimal unitPrice)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        if (unitPrice < 0) throw new ArgumentOutOfRangeException(nameof(unitPrice));
        return new InvoiceLine { Id = Guid.NewGuid(), Description = description, Quantity = quantity, UnitPrice = unitPrice };
    }
}