using RentCore.Domain.Abstractions;
using RentCore.Domain.Enums;

namespace RentCore.Domain.Entities;

public class Payment : BaseEntity<Guid>, IAuditableEntity
{
    public Guid InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaidOn { get;  set; }
    public PaymentMethod Method { get; set; }
    public PaymentStatus Status { get; set; }
    public string? Reference { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

}