using RentCore.Domain.Enums;

namespace RentCore.Application.Common.Interfaces
{
    public interface IVehicleAvailabilityNotifier
    {
        Task NotifyVehicleStatusChangedAsync(Guid branchId, Guid vehicleId, VehicleStatus newStatus);
    }
}
