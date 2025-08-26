using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;
using WebApi.Infrastructure.Configuration;

namespace WebApi.Infrastructure;
public class WebApiDbContext : DbContext
{
    public WebApiDbContext( DbContextOptions<WebApiDbContext> options ) : base( options ) { }

    public DbSet<Property> Properties { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<RoomType> RoomType { get; set; }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.ApplyConfiguration(new PropertyConfiguration() );
        modelBuilder.ApplyConfiguration(new ReservationConfiguration() );
        modelBuilder.ApplyConfiguration(new RoomTypeConfiguration() );
    }
}
