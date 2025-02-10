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
using Tours.Application.UseCases.Tours.Queries.GetListOfMountains;

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
        public async Task <ActionResult<List<TourViewModel>>> GetAllTours()
        {
            GetListOfToursQuery toursQuery = new GetListOfToursQuery();

            var toursDTO = await _mediator.Send(toursQuery);
            return Ok(toursDTO);
        }

        [HttpGet("{tourId}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TourViewModel>> GetTour([FromBody] GetTourQuery tourQuery)
        {
            var tourDTO = await _mediator.Send(tourQuery);
            return Ok(tourDTO);
        }

        [HttpGet("{mountainId}/tours")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TourViewModel>>> GetToursByMountainId([FromBody] GetToursByMountainIdQuery tourQuery)
        {
            var tourDTO = await _mediator.Send(tourQuery);
            return Ok(tourDTO);
        }

        [HttpPut("{tourId}/description")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTourDesctiption([FromBody] GetToursByMountainIdQuery tourQuery)
        {
            var tourDTO = await _mediator.Send(tourQuery);
            return Ok(tourDTO);
        }

        [HttpPut("{tourId}/numOfParticipants")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTourParticipants([FromBody] GetToursByMountainIdQuery tourQuery)
        {
            var tourDTO = await _mediator.Send(tourQuery);
            return Ok(tourDTO);
        }


        [HttpPost(Name = "AddTour")]
        public async Task<IActionResult> AddTour([FromBody] AddTourCommand addTourCommand)
        {
            if (addTourCommand == null || addTourCommand.AddTourDTO == null)
            {
                return BadRequest("Invalid payload");
            }
            await _mediator.Send(addTourCommand);
            
            return Accepted();
        }

        [HttpDelete(Name ="DeleteTour")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteTour([FromBody] DeleteTourCommand deleteTourCommand)
        {
            await _mediator.Send(deleteTourCommand);

            return Accepted();
        }
    }
}
