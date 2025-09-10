using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Repositories;
using WebApi.Domain.Entities;
using WebApi.Dto;
using WebApi.Map;

namespace WebApi.Controllers;

[Route( "/api/properties" )]
[ApiController]
public class PropertyController : ControllerBase
{
    private readonly IPropertyRepository _propertyRepository;

    public PropertyController( IPropertyRepository propertyRepository )
    {
        _propertyRepository = propertyRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PropertyResponseDto>>> GetAllProperties()
    {
        IEnumerable<Property> properties = await _propertyRepository.GetAll();
        return Ok( properties.Select( p => Mapper.MapToPropertyDto( p ) ) );
    }

    [HttpGet( "{id:int}" )]
    public async Task<ActionResult<PropertyResponseDto>> GetPropertyById( [FromRoute] int id )
    {
        Property? property = await _propertyRepository.GetById( id );
        if ( property is null ) return NotFound( "Property don't exist" );

        return Ok( Mapper.MapToPropertyDto( property ) );
    }

    [HttpPost]
    public async Task<ActionResult<PropertyResponseDto>> CreateProperty( [FromBody] PropertyCreateDto propertyDto )
    {
        Property? property = new Property
        {
            Name = propertyDto.Name,
            Country = propertyDto.Country,
            City = propertyDto.City,
            Address = propertyDto.Address,
            Latitude = propertyDto.Latitude,
            Longitude = propertyDto.Longitude
        };

        await _propertyRepository.Create( property );

        return CreatedAtAction( nameof( GetPropertyById ), new { id = property.Id }, Mapper.MapToPropertyDto( property ) );
    }

    [HttpPut( "{id:int}" )]
    public async Task<ActionResult<PropertyCreateDto>> UpdatePropery( [FromRoute] int id, [FromBody] PropertyCreateDto propertyDto )
    {
        Property? property = await _propertyRepository.GetById( id );
        if ( property is null ) return NotFound( "Property don't exist" );

        property.Name = propertyDto.Name;
        property.Country = propertyDto.Country;
        property.City = propertyDto.City;
        property.Address = propertyDto.Address;
        property.Latitude = propertyDto.Latitude;
        property.Longitude = propertyDto.Longitude;

        await _propertyRepository.Update( property );

        return NoContent();
    }

    [HttpDelete( "{id:int}" )]
    public async Task<ActionResult<Property>> DeleteProperty( [FromRoute] int id )
    {
        Property? property = await _propertyRepository.GetById( id );
        if ( property is null )
            return NotFound( "Property don't exist" );

        property.IsDeleted = true;

        await _propertyRepository.Update( property );
        return NoContent();
    }
}