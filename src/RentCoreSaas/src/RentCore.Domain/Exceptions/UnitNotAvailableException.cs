namespace RentCore.Domain.Exceptions;

public sealed class UnitNotAvailableException : DomainException
{
    public UnitNotAvailableException(Guid unitId, object currentStatus)
        : base($"Unit {unitId} is not available (status: {currentStatus}).") { }
}