using WebApi.Domain.Entities;

namespace WebApi.Domain.Repositories;
public interface IReservationRepository
{
    public Task Create( Reservation reservation );
    public Task<IEnumerable<Reservation>> GetAll();
    public Task<Reservation?> GetById( int id );
    public Task<IEnumerable<Reservation>> GetByPropertyId( int propertyId );
    public Task<IEnumerable<Reservation>?>? GetByGuest(string guestName, string? phoneNumber = null );
    public Task Update( Reservation reservation );
    public Task Delete( Reservation reservation );
}
