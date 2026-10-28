using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities
{
    public class MaintenanceVendor : BaseEntity<Guid>, IAuditableEntity
    {
        public string? Name { get; set; }
        public string? Specialty { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
