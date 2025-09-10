
using WebApi.Domain.Entities;

namespace WebApi.Domain.Repositories;
public interface IRoomTypeRepository
{
    public Task Create( RoomType roomType );
    public Task<IEnumerable<RoomType>> GetAll();
    public Task<RoomType?> GetById( int id );
    public Task<IEnumerable<RoomType>> GetByPropertyId( int propertyId );
    public Task<bool> IsRoomTypeAvailable( int roomTypeId, DateTime arrivalDate, DateTime departureDate );
    public Task Update( RoomType roomType );
}
