using Microsoft.AspNetCore.Mvc;
using MediatR;
using Tours.Application.UseCases.Tours.Queries.ViewModel;
using Tours.Application.UseCases.Tours.Queries.GetTour;
using Tours.Application.UseCases.Tours.Queries.GetListOfTours;
using Tours.Application.UseCases.Tours.Commands.DTOs;
using Tours.Application.UseCases.Tours.Commands.AddTour;
using Tours.Application.UseCases.Tours.Queries.GetToursByMountainId;
using Microsoft.AspNetCore.Cors;
using Tours.Application.UseCases.Tours.Commands.DeleteTour;
using Tours.Application.Common.Exceptions;

namespace Tours.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class ToursController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToursController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllTours")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TourViewModel>>> GetAllTours()
        {
            var toursQuery = new GetListOfToursQuery();
            var tours = await _mediator.Send(toursQuery);
            return Ok(tours);
        }

        [HttpGet("{tourId}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TourViewModel>> GetTour(GetTourQuery tourQuery)
        {
            var tour = await _mediator.Send(tourQuery);
            if (tour == null)
                throw new NotFoundException(nameof(Tour), tourQuery.TourId);
                
            return Ok(tour);
        }

        [HttpGet("{mountainId}/tours")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<TourViewModel>>> GetToursByMountainId(Guid mountainId)
        {
            var tourQuery = new GetToursByMountainIdQuery { MountainId = mountainId };
            var tours = await _mediator.Send(tourQuery);
            return Ok(tours);
        }

        [HttpPost(Name = "AddTour")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Unit>> AddTour([FromBody] AddTourCommand addTourCommand)
        {
            if (addTourCommand == null || addTourCommand.AddTourDTO == null)
            {
                throw new ValidationException(new[] { ("Tour", "Invalid tour data provided") });
            }
            
            await _mediator.Send(addTourCommand);
            return Accepted();
        }

        [HttpDelete(Name ="DeleteTour")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTour([FromBody] DeleteTourCommand deleteTourCommand)
        {
            await _mediator.Send(deleteTourCommand);
            return Ok();
        }
    }
}
