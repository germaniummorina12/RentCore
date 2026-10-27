using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities;

public sealed class Reservation : BaseEntity<Guid>, IAuditableEntity
{
    public Guid VehicleId { get; set; }
    public Guid CustomerId { get; set; }
    public DateOnly CheckIn { get; set; }
    public DateOnly CheckOut { get; set; } 
    public int PlannedKm { get; set; }
    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}