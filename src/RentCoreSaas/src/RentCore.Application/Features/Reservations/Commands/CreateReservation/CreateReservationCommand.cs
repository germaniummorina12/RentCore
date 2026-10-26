using MediatR;

namespace RentCore.Application.Features.Reservations.Commands.CreateReservation;

public sealed record CreateReservationCommand(
    Guid UnitId,
    Guid CustomerId,
    DateOnly CheckIn,
    DateOnly CheckOut,
    int GuestCount) : IRequest<Guid>;