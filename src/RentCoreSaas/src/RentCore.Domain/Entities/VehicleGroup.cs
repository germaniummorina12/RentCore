using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities
{
    public class VehicleGroup : BaseEntity<Guid>, IAuditableEntity
    {
        public Guid TenantId { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
