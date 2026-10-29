using FluentValidation;
using MediatR;
using RentCore.Application.Common.Helpers;
using RentCore.Application.Common.Interfaces;
using RentCore.Domain.Entities;

namespace RentCore.Application.Features.Reservations
{
    public class Add
    {
        public record Command(Guid vehicleId, Guid customerId, DateOnly checkIn, DateOnly checkOut, int? plannedKm) : IRequest<Response>
        {
            public Reservation toEntity() => new Reservation
            {
                VehicleId = vehicleId,
                CustomerId = customerId,
                CheckIn = checkIn,
                CheckOut = checkOut,
                PlannedKm = plannedKm,
                IsActive = true,
                CreatedBy = UserHelper.GetFullName()
            };
        }

        public class CommandHandler : IRequestHandler<Command, Response>
        {
            private IApplicationDbContext _context;
            private readonly IMediator _mediator;

            public Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
        public record CommandValidator : AbstractValidator<Command>
        {

        }
        public record Response(int id);
    }
}
