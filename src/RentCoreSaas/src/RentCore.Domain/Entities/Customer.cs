using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities
{
    public class Customer : BaseEntity<Guid>, IAuditableEntity
    {
        public Guid TenantId { get; set; }
        public string? FullName { get; set; } 
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
