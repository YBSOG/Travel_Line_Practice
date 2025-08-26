using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;
using WebApi.Dto;
using WebApi.Infrastructure.Repositories;
using WebApi.Map;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route( "/api/reservations" )]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationService _reservationService;

        public ReservationsController(
            IReservationRepository reservationRepository,
            IReservationService reservationService )
        {
            _reservationRepository = reservationRepository;
            _reservationService = reservationService;
        }

        [HttpGet( "search" )]
        public async Task<ActionResult<IEnumerable<SearchResultDto>>> SearchAvailableRooms(
            [FromQuery] string? city,
            [FromQuery] DateTime arrivalDate,
            [FromQuery] DateTime departureDate,
            [FromQuery] int personCount = 1,
            [FromQuery] decimal? maxPrice = null )
        {
            if ( arrivalDate >= departureDate )
                return BadRequest( "Arrival date must be before departure date" );

            SearchRequestDto searchRequest = new SearchRequestDto
            {
                City = city,
                ArrivalDate = arrivalDate,
                DepartureDate = departureDate,
                PersonCount = personCount,
                MaxPrice = maxPrice
            };

            IEnumerable<SearchResultDto> results = await _reservationService.SearchAvailableRooms( searchRequest );

            return Ok( results );
        }

        [HttpPost]
        public async Task<ActionResult<ReservationResponseDto>> CreateReservation( [FromBody] ReservationCreateDto reservationDto )
        {
            if ( reservationDto.ArrivalDate >= reservationDto.DepartureDate )
                return BadRequest( "Arrival date must be before departure date" );

            try
            {
                ReservationResponseDto reservation = await _reservationService.CreateReservation( reservationDto );
                return CreatedAtAction( nameof( GetReservationById ), new { id = reservation.Id } );
            }
            catch ( InvalidOperationException ex )
            {
                return BadRequest( ex.Message );
            }
            catch ( KeyNotFoundException ex )
            {
                return NotFound( ex.Message );
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationResponseDto>>> GetAllReservations()
        {
            IEnumerable<Reservation> reservations = await _reservationRepository.GetAll();
            return Ok( reservations.Select( r => Mapper.MapToReservationDto( r ) ) );
        }

        [HttpGet( "{id:int}" )]
        public async Task<ActionResult<ReservationResponseDto>> GetReservationById( [FromRoute] int id )
        {
            Reservation? reservation = await _reservationRepository.GetById( id );
            if ( reservation is null ) return NotFound( "Reservation don't exist" );

            return Ok( Mapper.MapToReservationDto( reservation ) );
        }

        [HttpDelete( "{id:int}" )]
        public async Task<IActionResult> CancelReservation( [FromRoute] int id )
        {
            bool result = await _reservationService.CancelReservation( id );
            if ( !result ) return NotFound( "Reservation don't exist" );

            return NoContent();
        }
    }
}
