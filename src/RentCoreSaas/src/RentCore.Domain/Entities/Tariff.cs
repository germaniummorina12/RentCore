using RentCore.Domain.Abstractions;
using RentCore.Domain.Enums;

namespace RentCore.Domain.Entities
{
    public class Tariff : BaseEntity<Guid>, IAuditableEntity
    {
        public Guid PriceListId { get; set; }
        public Guid VehicleGroupId { get; set; }
        public PeriodicType PeriodicType { get; set; }
        public KilometerType KilometerType { get; set; }
        public int MinDurationUnits { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal ExtraKmRate { get; set; }
        public decimal FollowingDayRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
