using RentCore.Domain.Abstractions;
using RentCore.Domain.Enums;

namespace RentCore.Domain.Entities
{
    public class Vehicle : BaseEntity<Guid>, IAuditableEntity
    {
        public Guid BranchId { get; set; }
        public Guid VehicleGroupId { get; set; }
        public string? VehicleNumber { get; set; }
        public string? LicensePlate { get; set; }
        public string? Model { get; set; }
        public int Mileage { get; set; }
        public VehicleStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
