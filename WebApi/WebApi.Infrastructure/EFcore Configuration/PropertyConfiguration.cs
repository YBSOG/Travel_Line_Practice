using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Configuration;
public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure( EntityTypeBuilder<Property> builder )
    {
        builder.HasKey( p => p.Id );
        builder.Property( p => p.Name ).HasMaxLength( 50 ).IsRequired();
        builder.Property( p => p.Country ).HasMaxLength( 30 ).IsRequired();
        builder.Property( p => p.City ).HasMaxLength( 30 ).IsRequired();
        builder.Property( p => p.Address ).HasMaxLength( 30 ).IsRequired();
        builder.Property( p => p.Latitude ).HasColumnType( "decimal(9,6)" ).IsRequired();
        builder.Property( p => p.Longitude ).HasColumnType( "decimal(9,6)" ).IsRequired();

        builder.HasMany( p => p.RoomTypes )
            .WithOne( rt => rt.Property )
            .HasForeignKey( rt => rt.PropertyId )
            .OnDelete( DeleteBehavior.Cascade );

        builder.HasMany( p => p.Reservations )
            .WithOne( r => r.Property )
            .HasForeignKey( r => r.PropertyId )
            .OnDelete( DeleteBehavior.Restrict );
    }
}
