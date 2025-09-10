using WebApi.Domain.Entities;

namespace WebApi.Domain.Repositories;
public interface IPropertyRepository
{
    public Task Create( Property property );
    public Task<IEnumerable<Property>> GetAll();
    public Task<Property?> GetById( int id );
    public Task<IEnumerable<Property?>?> Search( string? city, int? minPersonCount, int? maxPersonCount, decimal? maxPrice );
    public Task Update( Property property );
}