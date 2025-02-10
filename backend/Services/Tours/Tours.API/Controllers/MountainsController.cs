using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tours.Application.UseCases.Tours.Queries.GetListOfMountains;
using Tours.Application.UseCases.Tours.Queries.ViewModel;

namespace Tours.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class MountainsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MountainsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllMountains")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MountainViewModel>>> GetAllMountains()
        {
            GetListOfMountainsQuery mountainsQuery = new GetListOfMountainsQuery();

            var mountainsDTO = await _mediator.Send(mountainsQuery);
            return Ok(mountainsDTO);
        }
    }
}
