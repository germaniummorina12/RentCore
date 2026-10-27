using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities
{
    public class Tenant : BaseEntity<Guid>, IAuditableEntity
    {
        public string? CompanyName { get; set; }
        public string? Slug { get; set; }
        public string? ContactEmail { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

    }
}
