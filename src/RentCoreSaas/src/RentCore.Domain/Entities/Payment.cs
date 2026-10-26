using RentCore.Domain.Abstractions;
using RentCore.Domain.Enums;

namespace RentCore.Domain.Entities;

public sealed class Payment : BaseEntity<Guid>, IAuditableEntity
{
    public Guid InvoiceId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime PaidOn { get; private set; }
    public PaymentMethod Method { get; private set; }
    public string? Reference { get; private set; }

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    private Payment() { }

    public static Payment Create(Guid invoiceId, decimal amount, PaymentMethod method, string? reference) => new()
    {
        Id = Guid.NewGuid(),
        InvoiceId = invoiceId,
        Amount = amount,
        Method = method,
        Reference = reference,
        PaidOn = DateTime.UtcNow
    };
}