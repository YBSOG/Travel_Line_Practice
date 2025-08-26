
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;

namespace WebApi.Infrastructure.Repositories;
public class PropertyRepository : IPropertyRepository
{
    private readonly WebApiDbContext _dbContext;

    public PropertyRepository( WebApiDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public async Task Create( Property property )
    {
        _dbContext.Properties.Add( property );
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Property>> GetAll()
    {
        return await _dbContext.Properties
            .Include( p => p.RoomTypes )
            .ToListAsync();
    }

    public async Task<Property?> GetById( int id )
    {
        return await _dbContext.Set<Property>()
            .Include( p => p.RoomTypes )
            .FirstOrDefaultAsync( p => p.Id == id );
    }

    public async Task<IEnumerable<Property>> GetByCity( string city )
    {
        return await _dbContext.Set<Property>()
            .Include( p => p.RoomTypes )
            .Where( p => p.City.ToLower() == city.ToLower() )
            .ToListAsync();
    }

    public async Task<IEnumerable<Property?>?> Search( string? city, int? minPersonCount, int? maxPersonCount, decimal? maxPrice )
    {
        IQueryable<Property> query = _dbContext.Set<Property>()
                                    .Include( p => p.RoomTypes )
                                    .AsQueryable();

        if ( !string.IsNullOrEmpty( city ) )
        {
            query = query.Where( p => p.City.ToLower().Contains( city.ToLower() ) );
        }

        if ( minPersonCount.HasValue )
        {
            query = query.Where( p => p.RoomTypes.Any( rt => rt.MinPersonCount >= minPersonCount.Value ) );
        }

        if ( maxPersonCount.HasValue )
        {
            query = query.Where( p => p.RoomTypes.Any( rt => rt.MaxPersonCount <= maxPersonCount.Value ) );
        }

        if ( maxPrice.HasValue )
        {
            query = query.Where( p => p.RoomTypes.Any( rt => rt.DailyPrice <= maxPrice.Value ) );
        }

        return await query.ToListAsync();
    }

    public async Task Update( Property property )
    {
        _dbContext.Properties.Update( property );
         await _dbContext.SaveChangesAsync();
    }

    public async Task Delete( Property property )
    {
        _dbContext.Properties.Remove( property );
        await _dbContext.SaveChangesAsync();
    }
}
