using Microsoft.AspNetCore.Mvc;
using MediatR;

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
        public void GetAllTours()
        {
        }

        [HttpGet("{tourId}")]
        public void GetTour(string tourId)
        {
        }
    }
}
