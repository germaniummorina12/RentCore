using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities
{
    public class VehicleBrand : BaseEntity<Guid>, IAuditableEntity
    {
        public string? NameDe { get; set; }
        public string? NameEn { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
