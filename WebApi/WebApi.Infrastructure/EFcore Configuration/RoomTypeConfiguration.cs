using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Configuration;
public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure( EntityTypeBuilder<RoomType> builder )
    {
        builder.HasKey( rt => rt.Id );
        builder.Property( rt => rt.Name ).IsRequired().HasMaxLength( 50 );
        builder.Property( rt => rt.DailyPrice ).HasColumnType( "decimal(18,2)" ).IsRequired();
        builder.Property( rt => rt.Currency ).HasMaxLength( 3 ).HasDefaultValue( "USD" );
        builder.Property( rt => rt.MinPersonCount ).IsRequired();
        builder.Property( rt => rt.MaxPersonCount ).IsRequired();

        builder.Property( rt => rt.Services )
            .HasConversion(
            v => string.Join( ',', v ),
            v => v.Split( ',', StringSplitOptions.RemoveEmptyEntries ).ToList() );

        builder.Property( rt => rt.Amenities )
            .HasConversion(
            v => string.Join( ',', v ),
            v => v.Split( ',', StringSplitOptions.RemoveEmptyEntries ).ToList() );

        builder.HasMany( rt => rt.Reservations )
            .WithOne( r => r.RoomType )
            .HasForeignKey( rt => rt.RoomTypeId )
            .OnDelete( DeleteBehavior.Restrict );
    }
}
