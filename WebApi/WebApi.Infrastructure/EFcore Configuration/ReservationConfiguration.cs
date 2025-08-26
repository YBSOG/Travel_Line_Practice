using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Configuration;
public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure( EntityTypeBuilder<Reservation> builder )
    {
        builder.HasKey( r => r.Id );
        builder.Property( r => r.ArrivalDate ).IsRequired();
        builder.Property( r => r.DepartureDate ).IsRequired();
        builder.Property( r => r.ArrivalTime ).IsRequired();
        builder.Property( r => r.DepartureTime ).IsRequired();
        builder.Property( r => r.GuestName ).HasMaxLength( 50 ).IsRequired();
        builder.Property( r => r.GuestPhoneNumber ).HasMaxLength( 15 ).IsRequired();
        builder.Property( r => r.Total ).HasColumnType( "decimal(18,2)" ).IsRequired();
        builder.Property( r => r.Currency ).HasMaxLength( 3 ).HasDefaultValue( "USD" ).IsRequired();
        builder.Property( r => r.IsCancelled ).HasDefaultValue( false );

        builder.HasOne( r => r.Property )
            .WithMany( p => p.Reservations )
            .HasForeignKey( r => r.PropertyId )
            .OnDelete( DeleteBehavior.Restrict );

        builder.HasOne( r => r.RoomType )
            .WithMany( rt => rt.Reservations )
            .HasForeignKey( r => r.RoomTypeId )
            .OnDelete( DeleteBehavior.Restrict );
    }
}
