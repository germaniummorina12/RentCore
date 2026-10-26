namespace RentCore.Domain.Exceptions;

public sealed class InvalidReservationStateException : DomainException
{
    public InvalidReservationStateException(string attemptedAction, object currentStatus)
        : base($"Cannot {attemptedAction} a reservation that is currently {currentStatus}.") { }
}