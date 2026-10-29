using Microsoft.EntityFrameworkCore;
using RentCore.Domain.Entities;

namespace RentCore.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Tenant> Tenants { get; }
    Guid? TenantId { get; }
    DbSet<Branch> Branches { get; }
    DbSet<Country> Countries { get; }
    DbSet<Customer> Customers { get; }
    DbSet<Reservation> Reservations { get; }
    DbSet<Invoice> Invoices { get; }
    DbSet<Payment> Payments { get; }
    DbSet<MaintenanceRequest> MaintenanceRequests { get; }
    DbSet<Equipment> Equipments { get; }
    DbSet<FuelType> FuelTypes { get; }
    DbSet<GearboxType> GearboxTypes { get; }
    DbSet<Document> Documents { get; }
    DbSet<Notification> Notifications { get; }
    DbSet<InvoiceLine> InvoiceLines { get; }
    DbSet<RentalAgreement> RentalAgreements { get; }
    DbSet<Review> Reviews { get; }
    DbSet<DiscountCode> DiscountCodes { get; }
    DbSet<MaintenanceVendor> MaintenanceVendors { get; }
    DbSet<PriceList> PriceLists { get; }
    DbSet<RentalAgreementEquipment> RentalAgreementEquipments { get; }
    DbSet<Tariff> Tariffs { get; }
    DbSet<Vehicle> Vehicles { get; }
    DbSet<VehicleBrand> VehicleBrands { get; }
    DbSet<VehicleGroup> VehicleGroups { get; }
    DbSet<RolePermission> RolePermissions { get; }
    DbSet<AuditLog> AuditLogs { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}