using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities
{
    public class AuditLog : BaseEntity<Guid>
    {
        public string? EntityName { get; set; }
        public Guid EntityId { get; set; }
        public string? Action { get; set; }
        public string? ChangedBy { get; set; }
    }
}
