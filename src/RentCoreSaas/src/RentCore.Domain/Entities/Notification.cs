using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities
{
    public class Notification : BaseEntity<Guid>, IAuditableEntity
    {
        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
