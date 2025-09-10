using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Configuration;
public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    readonly ValueComparer _listComparer = new ValueComparer<List<string>>(
            (c1, c2) => c1 != null && c2 != null && c1.SequenceEqual( c2 ),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());

    public void Configure( EntityTypeBuilder<RoomType> builder )
    {
        builder.HasKey( rt => rt.Id );
        builder.Property( rt => rt.Name ).IsRequired().HasMaxLength( 50 );
        builder.Property( rt => rt.DailyPrice ).HasColumnType( "decimal(18,2)" ).IsRequired();
        builder.Property( rt => rt.Currency ).HasMaxLength( 3 ).HasDefaultValue( "USD" );
        builder.Property( rt => rt.MinPersonCount ).IsRequired();
        builder.Property( rt => rt.MaxPersonCount ).IsRequired();
        builder.Property( rt => rt.IsDeleted ).HasDefaultValue( false ).IsRequired();

        builder.Property( rt => rt.Services )
            .HasConversion(
            v => string.Join( ',', v ),
            v => v.Split( ',', StringSplitOptions.RemoveEmptyEntries ).ToList() )
            .Metadata.SetValueComparer( _listComparer );

        builder.Property( rt => rt.Amenities )
            .HasConversion(
            v => string.Join( ',', v ),
            v => v.Split( ',', StringSplitOptions.RemoveEmptyEntries ).ToList() )
            .Metadata.SetValueComparer( _listComparer );

        builder.HasMany( rt => rt.Reservations )
            .WithOne( r => r.RoomType )
            .HasForeignKey( rt => rt.RoomTypeId )
            .OnDelete( DeleteBehavior.Restrict );

    }
}

