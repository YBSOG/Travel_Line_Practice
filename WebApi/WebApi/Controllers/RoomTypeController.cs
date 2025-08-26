using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;
using WebApi.Dto;
using WebApi.Map;

namespace WebApi.Controllers
{
    [Route( "/api/roomtypes" )]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IPropertyRepository _propertyRepository;

        public RoomTypeController(
            IRoomTypeRepository roomTypeRepository,
            IPropertyRepository propertyRepository )
        {
            _roomTypeRepository = roomTypeRepository;
            _propertyRepository = propertyRepository;
        }

        [HttpGet( "/properties/{propertyId:int}/roomtypes" )]
        public async Task<ActionResult<IEnumerable<RoomTypeResponseDto>>> GetRoomTypesByProperty( [FromRoute] int propertyId )
        {
            Property? property = await _propertyRepository.GetById( propertyId );
            if ( property is null ) return NotFound( "Property don't exist" );

            IEnumerable<RoomType> roomType = await _roomTypeRepository.GetByPropertyId( propertyId );
            return Ok( roomType.Select( rt => Mapper.MapToRoomTypeDto( rt ) ) );
        }

        [HttpGet( "{id:int}" )]
        public async Task<ActionResult<RoomTypeResponseDto>> GetRoomById( [FromRoute] int id )
        {
            RoomType? roomType = await _roomTypeRepository.GetById( id );
            if ( roomType is null ) return NotFound( "RoomType don't exist" );

            return Ok( Mapper.MapToRoomTypeDto( roomType ) );
        }

        [HttpPost]
        public async Task<ActionResult<RoomTypeResponseDto>> CreateRoomType( [FromBody] RoomTypeResponseDto roomTypeDto )
        {
            Property? property = await _propertyRepository.GetById( roomTypeDto.PropertyId );
            if ( property is null ) return BadRequest( "Property don't exist" );

            RoomType roomType = new RoomType
            {
                PropertyId = roomTypeDto.Id,
                Name = roomTypeDto.Name,
                DailyPrice = roomTypeDto.DailyPrice,
                Currency = roomTypeDto.Currency,
                MinPersonCount = roomTypeDto.MinPersonCount,
                MaxPersonCount = roomTypeDto.MaxPersonCount,
                Services = roomTypeDto.Services,
                Amenities = roomTypeDto.Amenities
            };

            await _roomTypeRepository.Create( roomType );
            return CreatedAtAction( nameof( GetRoomById ), new { id = roomType.Id }, Mapper.MapToRoomTypeDto( roomType ) );
        }

        [HttpPut( "{id:int}" )]
        public async Task<ActionResult<RoomType>> UpdateRoomType( [FromRoute] int id, [FromBody] RoomTypeCreateDto roomTypeDto )
        {
            RoomType? roomType = await _roomTypeRepository.GetById( id );
            if ( roomType is null ) return NotFound( "RoomType don't exist" );

            roomType.Name = roomTypeDto.Name;
            roomType.DailyPrice = roomTypeDto.DailyPrice;
            roomType.Currency = roomTypeDto.Currency;
            roomType.MinPersonCount = roomTypeDto.MinPersonCount;
            roomType.MaxPersonCount = roomTypeDto.MaxPersonCount;
            roomType.Services = roomTypeDto.Services;
            roomType.Amenities = roomTypeDto.Amenities;

            await _roomTypeRepository.Update( roomType );
            return NoContent();
        }

        [HttpDelete( "{id:int}" )]
        public async Task<ActionResult<RoomType>> DeleteRoomType( [FromRoute] int id )
        {
            RoomType? roomType = await _roomTypeRepository.GetById( id );
            if ( roomType is null ) return NotFound( "RoomType don't exist" );

            await _roomTypeRepository.Delete( roomType );
            return NoContent();
        }
    }
}
