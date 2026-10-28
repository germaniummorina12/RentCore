using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities
{
    public class Review : BaseEntity<Guid>, IAuditableEntity
    {
        public Guid ReservationId { get; set; }
        public Guid CustomerId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
