using RentCore.Domain.Abstractions;
using RentCore.Domain.Enums;

namespace RentCore.Domain.Entities
{
    public class MaintenanceRequest : BaseEntity<Guid>, IAuditableEntity
    {
        public Guid VehicleId { get; set; }
        public Guid ReportedByUserId { get; set; }
        public string? Description { get; set; }
        public MaintenancePriority Priority { get; set; }
        public MaintenanceStatus Status { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
