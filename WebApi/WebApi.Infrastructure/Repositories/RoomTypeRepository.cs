
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;

namespace WebApi.Infrastructure.Repositories;
public class RoomTypeRepository : IRoomTypeRepository
{
    private readonly WebApiDbContext _dbContext;

    public RoomTypeRepository( WebApiDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public async Task Create( RoomType roomType )
    {
        _dbContext.RoomType.Add( roomType );
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<RoomType>> GetAll()
    {
        return await _dbContext.RoomType.ToListAsync();
    }

    public async Task<RoomType?> GetById( int id )
    {
        return await _dbContext.Set<RoomType>().FirstOrDefaultAsync( p => p.Id == id );
    }

    public async Task<IEnumerable<RoomType>> GetByPropertyId( int propertyId )
    {
        return await _dbContext.RoomType.Where( rt => rt.PropertyId == propertyId ).ToListAsync();
    }

    public async Task<bool> IsRoomTypeAvailable( int roomTypeId, DateTime arrivalDate, DateTime departureDate )
    {
        int conflictingReservations = await _dbContext.Reservations
            .Where( r => r.RoomTypeId == roomTypeId &&
                         !r.IsCancelled &&
                         r.ArrivalDate < departureDate &&
                         r.DepartureDate > arrivalDate )
            .CountAsync();

        if ( conflictingReservations is 0 )
            return true;
        else
            return false;
    }

    public async Task Update( RoomType roomType )
    {
        _dbContext.RoomType.Update( roomType );
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete( RoomType roomType )
    {
        _dbContext.RoomType.Remove( roomType );
        await _dbContext.SaveChangesAsync();
    }
}
