using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities
{
    public class PriceList : BaseEntity<Guid>, IAuditableEntity
    {
        public Guid TenantId { get; set; }
        public string? Name { get; set; }
        public bool IsGross { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
