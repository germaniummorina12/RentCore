using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities
{
    public class Branch : BaseEntity<Guid>, IAuditableEntity
    {
        public Guid TenantId { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
