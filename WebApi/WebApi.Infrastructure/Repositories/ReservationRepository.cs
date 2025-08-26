using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;

namespace WebApi.Infrastructure.Repositories;
public class ReservationRepository : IReservationRepository
{
    private readonly WebApiDbContext _dbContext;

    public ReservationRepository( WebApiDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public async Task Create( Reservation reservation )
    {
        _dbContext.Reservations.Add( reservation );
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Reservation>> GetAll()
    {
        return await _dbContext.Reservations
                    .Include( r => r.Property )
                    .Include( r => r.RoomType )
                    .Where( r => r.IsCancelled )
                    .ToListAsync();
    }

    public async Task<Reservation?> GetById( int id )
    {
        return await _dbContext.Reservations
                    .Include( r => r.Property )
                    .Include( r => r.RoomType )
                    .FirstOrDefaultAsync( p => p.Id == id );
    }

    public async Task<IEnumerable<Reservation>> GetByPropertyId( int propertyId )
    {
        return await _dbContext.Reservations
            .Include( r => r.Property )
            .Include( r => r.RoomType )
            .Where( r => r.PropertyId == propertyId && !r.IsCancelled )
            .ToListAsync();
    }

    public async Task<IEnumerable<Reservation>?>? GetByGuest( string guestName, string? phoneNumber = null )
    {
        IQueryable<Reservation> query = _dbContext.Reservations
                                       .Include( r => r.Property )
                                       .Include( r => r.RoomType )
                                       .Where( r => !r.IsCancelled &&
                                       r.GuestName.Equals( guestName, StringComparison.CurrentCultureIgnoreCase ) );

        if ( !string.IsNullOrEmpty( phoneNumber ) )
            query = query.Where( r => r.GuestPhoneNumber.Contains( phoneNumber ) );

        return await query.ToListAsync();
    }

    public async Task Update( Reservation reservation )
    {
        _dbContext.Reservations.Update( reservation );
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete( Reservation reservation )
    {
        _dbContext.Reservations.Remove( reservation );
        await _dbContext.SaveChangesAsync();
    }
}
