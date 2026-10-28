using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities
{
    public class DiscountCode : BaseEntity<Guid>, IAuditableEntity
    {
        public string? Code { get; set; }
        public decimal PercentOff { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int MaxRedemptions { get; set; }
        public int RedeemedCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
