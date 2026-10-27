namespace RentCore.Domain.Exceptions;

public sealed class VehicleNotAvailableException : DomainException
{
    public VehicleNotAvailableException(Guid vehicleId, object currentStatus)
        : base($"Vehicle {vehicleId} is not available (status: {currentStatus}).") { }
}