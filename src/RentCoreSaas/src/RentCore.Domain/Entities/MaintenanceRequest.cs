using RentCore.Domain.Abstractions;
using RentCore.Domain.Enums;

namespace RentCore.Domain.Entities
{
    public sealed class MaintenanceRequest : BaseEntity<Guid>, IAuditableEntity
    {
        public Guid UnitId { get; private set; }
        public Guid ReportedByUserId { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public MaintenancePriority Priority { get; private set; }
        public MaintenanceStatus Status { get; private set; }
        public DateTime ResolvedAt { get; private set; }

    }
}
