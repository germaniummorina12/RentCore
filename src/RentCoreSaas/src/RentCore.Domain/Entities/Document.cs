using RentCore.Domain.Abstractions;
using RentCore.Domain.Enums;

namespace RentCore.Domain.Entities
{
    public class Document : BaseEntity<Guid>, IAuditableEntity
    {
        public DocumentOwnerType OwnerType { get; set; }
        public Guid OwnerId { get; set; }
        public string? FileName { get; set; }
        public string? StoragePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

    }
}
