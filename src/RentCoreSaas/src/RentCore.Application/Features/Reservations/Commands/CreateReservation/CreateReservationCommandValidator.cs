using FluentValidation;

namespace RentCore.Application.Features.Reservations.Commands.CreateReservation;

public sealed class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationCommandValidator()
    {
        RuleFor(x => x.UnitId).NotEmpty();
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.GuestCount).GreaterThanOrEqualTo(1);
        RuleFor(x => x.CheckOut).GreaterThan(x => x.CheckIn)
            .WithMessage("Check-out must be after check-in.");
    }
}