using RentCore.Domain.Abstractions;
using RentCore.Domain.Enums;
using RentCore.Domain.Exceptions;

namespace RentCore.Domain.Entities;

public sealed class Reservation : BaseEntity<Guid>, IAuditableEntity
{
    public Guid UnitId { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateOnly CheckIn { get; private set; }
    public DateOnly CheckOut { get; private set; }
    public int GuestCount { get; private set; }
    public ReservationStatus Status { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string? Notes { get; private set; }
    public Guid? DiscountCodeId { get; private set; }

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }

    private Reservation() { }

    public static Reservation Create(Guid unitId, Guid customerId, DateOnly checkIn, DateOnly checkOut, int guestCount, decimal totalAmount)
    {
        if (checkOut <= checkIn)
            throw new ArgumentException("Check-out must be after check-in.");
        if (guestCount <= 0)
            throw new ArgumentOutOfRangeException(nameof(guestCount));

        return new Reservation
        {
            Id = Guid.NewGuid(),
            UnitId = unitId,
            CustomerId = customerId,
            CheckIn = checkIn,
            CheckOut = checkOut,
            GuestCount = guestCount,
            TotalAmount = totalAmount,
            Status = ReservationStatus.Pending
        };
    }

    public void Confirm()
    {
        if (Status != ReservationStatus.Pending)
            throw new InvalidReservationStateException("confirm", Status);
        Status = ReservationStatus.Confirmed;
    }

    public void CheckInGuest()
    {
        if (Status != ReservationStatus.Confirmed)
            throw new InvalidReservationStateException("check in", Status);
        Status = ReservationStatus.CheckedIn;
    }

    public void CheckOutGuest()
    {
        if (Status != ReservationStatus.CheckedIn)
            throw new InvalidReservationStateException("check out", Status);
        Status = ReservationStatus.CheckedOut;
    }

    public void Cancel(string reason)
    {
        if (Status is ReservationStatus.CheckedOut or ReservationStatus.Cancelled)
            throw new InvalidReservationStateException("cancel", Status);
        Status = ReservationStatus.Cancelled;
        Notes = reason;
    }

    public bool OverlapsWith(DateOnly otherCheckIn, DateOnly otherCheckOut)
        => Status != ReservationStatus.Cancelled
           && CheckIn < otherCheckOut && otherCheckIn < CheckOut;

    public void ApplyDiscount(Guid discountCodeId) => DiscountCodeId = discountCodeId;
}