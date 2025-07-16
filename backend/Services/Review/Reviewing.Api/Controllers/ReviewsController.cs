using Microsoft.AspNetCore.Mvc;
using Reviewing.Application.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace Reviewing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all reviews", Description = "Returns a list of all reviews.")]
        [SwaggerResponse(StatusCodes.Status200OK, "List of reviews returned", typeof(IEnumerable<ReadReviewDto>))]
        public async Task<ActionResult<IEnumerable<ReadReviewDto>>> GetAll()
        {
            // TODO: Retrieve all reviews
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieve a review by ID", Description = "Returns a single review by its unique ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Review found", typeof(ReadReviewDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Review not found")]
        public async Task<ActionResult<ReadReviewDto>> GetById(int id)
        {
            // TODO: Retrieve a review by ID
            throw new NotImplementedException();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new review", Description = "Creates a new review and returns the created entity.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Review created", typeof(ReadReviewDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input")]
        public async Task<ActionResult<CreateReviewDto>> Create([FromBody] CreateReviewDto dto)
        {
            // TODO: Create a new review
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a review", Description = "Updates an existing review by its ID.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Review updated")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Review not found")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateReviewDto dto)
        {
            // TODO: Update an existing review
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a review", Description = "Deletes a review by its unique ID.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Review deleted")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Review not found")]
        public async Task<IActionResult> Delete(int id)
        {
            // TODO: Delete a review by ID
            throw new NotImplementedException();
        }
    }
}
