using RentCore.Domain.Abstractions;
using RentCore.Domain.Enums;

namespace RentCore.Domain.Entities;

public sealed class Invoice : BaseEntity<Guid>, IAuditableEntity
{
    private readonly List<InvoiceLine> _lines = new();

    public Guid ReservationId { get; private set; }
    public string InvoiceNumber { get; private set; } = string.Empty;
    public DateTime IssueDate { get; private set; }
    public DateTime DueDate { get; private set; }
    public InvoiceStatus Status { get; private set; } = InvoiceStatus.Unpaid;
    public IReadOnlyCollection<InvoiceLine> Lines => _lines.AsReadOnly();
    public decimal TotalAmount => _lines.Sum(l => l.LineTotal);

    private decimal _amountPaid;

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    private Invoice() { }

    public static Invoice Create(Guid reservationId, string invoiceNumber, DateTime dueDate) => new()
    {
        Id = Guid.NewGuid(),
        ReservationId = reservationId,
        InvoiceNumber = invoiceNumber,
        IssueDate = DateTime.UtcNow,
        DueDate = dueDate,
        Status = InvoiceStatus.Unpaid
    };

    public void AddLine(string description, int quantity, decimal unitPrice)
    {
        if (Status == InvoiceStatus.Void)
            throw new InvalidOperationException("Cannot add lines to a void invoice.");
        _lines.Add(InvoiceLine.Create(description, quantity, unitPrice));
    }

    public void RegisterPayment(decimal amount)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        _amountPaid += amount;
        Status = _amountPaid >= TotalAmount ? InvoiceStatus.Paid
                : _amountPaid > 0 ? InvoiceStatus.PartiallyPaid
                : Status;
    }
}