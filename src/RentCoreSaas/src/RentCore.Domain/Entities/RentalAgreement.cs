using RentCore.Domain.Abstractions;
using RentCore.Domain.Enums;

namespace RentCore.Domain.Entities
{
    public class RentalAgreement : BaseEntity<Guid>, IAuditableEntity
    {
        public Guid ReservationId { get; set; }
        public Guid VehicleId { get; set; }
        public Guid CustomerId { get; set; }
        public int HandoverKm { get; set; }
        public int ReturnKm { get; set; }
        public RentalAgreementStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
