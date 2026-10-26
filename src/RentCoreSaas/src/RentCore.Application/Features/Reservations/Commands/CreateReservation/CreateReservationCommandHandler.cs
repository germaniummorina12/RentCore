using MediatR;
using Microsoft.EntityFrameworkCore;
using RentCore.Application.Common.Interfaces;
using RentCore.Domain.Entities;
using RentCore.Domain.Exceptions;

namespace RentCore.Application.Features.Reservations.Commands.CreateReservation;

public sealed class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateReservationCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var unit = await _context.Units.FirstOrDefaultAsync(u => u.Id == request.UnitId, cancellationToken)
            ?? throw new KeyNotFoundException($"Unit {request.UnitId} was not found.");

        if (!unit.IsBookable())
            throw new UnitNotAvailableException(unit.Id, unit.Status);

        var overlapping = await _context.Reservations
            .Where(r => r.UnitId == request.UnitId)
            .ToListAsync(cancellationToken);

        if (overlapping.Any(r => r.OverlapsWith(request.CheckIn, request.CheckOut)))
            throw new InvalidOperationException("The unit is already reserved for part of that date range.");

        var nights = request.CheckOut.DayNumber - request.CheckIn.DayNumber;
        var totalAmount = nights * unit.BaseNightlyRate;

        var reservation = Reservation.Create(
            request.UnitId, request.CustomerId, request.CheckIn, request.CheckOut,
            request.GuestCount, totalAmount);

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync(cancellationToken);

        return reservation.Id;
    }
}