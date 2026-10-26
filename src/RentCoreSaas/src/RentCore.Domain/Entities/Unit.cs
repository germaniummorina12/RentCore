using RentCore.Domain.Abstractions;
using RentCore.Domain.Enums;
using RentCore.Domain.Exceptions;

namespace RentCore.Domain.Entities;

public sealed class Unit : BaseEntity<Guid>, IAuditableEntity
{
    public Guid PropertyId { get; private set; }
    public string UnitNumber { get; private set; } = string.Empty;
    public int Bedrooms { get; private set; }
    public decimal BaseNightlyRate { get; private set; }
    public UnitStatus Status { get; private set; } = UnitStatus.Available;

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    private Unit() { } // EF Core materialization

    public static Unit Create(Guid propertyId, string unitNumber, int bedrooms, decimal baseNightlyRate)
    {
        if (string.IsNullOrWhiteSpace(unitNumber))
            throw new ArgumentException("Unit number is required.", nameof(unitNumber));
        if (baseNightlyRate <= 0)
            throw new ArgumentOutOfRangeException(nameof(baseNightlyRate), "Nightly rate must be positive.");

        return new Unit
        {
            Id = Guid.NewGuid(),
            PropertyId = propertyId,
            UnitNumber = unitNumber,
            Bedrooms = bedrooms,
            BaseNightlyRate = baseNightlyRate,
            Status = UnitStatus.Available
        };
    }

    public void MarkOccupied()
    {
        if (Status == UnitStatus.UnderMaintenance)
            throw new UnitNotAvailableException(Id, Status);
        Status = UnitStatus.Occupied;
    }

    public void MarkAvailable() => Status = UnitStatus.Available;

    public void MarkUnderMaintenance() => Status = UnitStatus.UnderMaintenance;

    public bool IsBookable() => Status == UnitStatus.Available;
}