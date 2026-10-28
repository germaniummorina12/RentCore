using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities
{
    public class Country : BaseEntity<Guid>, IAuditableEntity
    {
        public string? Name { get; set; }
        public string? IsoCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
