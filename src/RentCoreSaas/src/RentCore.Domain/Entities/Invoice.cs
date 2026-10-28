using RentCore.Domain.Abstractions;
using RentCore.Domain.Enums;

namespace RentCore.Domain.Entities;

public class Invoice : BaseEntity<Guid>, IAuditableEntity
{
    public Guid RentalAgreementId { get; set; }
    public Guid CustomerId {get; set; }
    public string? InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public List<InvoiceLine> Lines {get; set; } = new();
    public decimal NetTotal { get; set; }
    public decimal VatTotal { get; set; }
    public string? InvoiceType { get; set; }
    public InvoiceStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

}