using Microsoft.AspNetCore.Mvc;
using MediatR;
using Tours.Application.UseCases.Tours.Queries.ViewModel;
using Tours.Application.UseCases.Tours.Queries.GetTour;
using Tours.Application.UseCases.Tours.Queries.GetListOfTours;
using Tours.Application.UseCases.Tours.Commands.DTOs;
using Tours.Application.UseCases.Tours.Commands.AddTour;

namespace Tours.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpPost(Name = "AddTour")]
        public async Task<IActionResult> AddTour([FromBody] AddTourCommand addTourCommand)
        {
            await _mediator.Send(addTourCommand);
            return Accepted();
        }
    }
}
