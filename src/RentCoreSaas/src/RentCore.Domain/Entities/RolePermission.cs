using RentCore.Domain.Abstractions;

namespace RentCore.Domain.Entities
{
    public class RolePermission : BaseEntity<Guid>
    {
        public string? RoleName { get; set; }
        public string? PermissionCode { get; set; }
    }
}
