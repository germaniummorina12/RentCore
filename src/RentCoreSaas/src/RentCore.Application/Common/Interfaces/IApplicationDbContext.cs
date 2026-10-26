using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentCore.Domain.Entities;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

namespace RentCore.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Tenant> Tenants { get; }
    DbSet<Branch> Branches { get; }
    DbSet<Property> Properties { get; }
    DbSet<Unit> Units { get; }
    DbSet<Customer> Customers { get; }
    DbSet<Reservation> Reservations { get; }
    DbSet<Invoice> Invoices { get; }
    DbSet<Payment> Payments { get; }
    DbSet<MaintenanceRequest> MaintenanceRequests { get; }
    DbSet<Amenity> Amenities { get; }
    DbSet<UnitAmenity> UnitAmenities { get; }
    DbSet<SeasonalRate> SeasonalRates { get; }
    DbSet<Document> Documents { get; }
    DbSet<Notification> Notifications { get; }
    DbSet<Country> Countries { get; }
    DbSet<RentalAgreement> RentalAgreements { get; }
    DbSet<Review> Reviews { get; }
    DbSet<DiscountCode> DiscountCodes { get; }
    DbSet<MaintenanceVendor> MaintenanceVendors { get; }
    DbSet<AuditLog> AuditLogs { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}