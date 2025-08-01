using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Reviewing.Application.DTOs;
using Reviewing.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using Reviewing.Domain.Entities;
using Reviewing.Application.Pagination;

namespace Reviewing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(LoggingActionFilter))]
    public class ReviewsController(ReviewRepository reviewRepository, IMapper mapper) : ControllerBase
    {
        protected readonly ReviewRepository _reviewRepository = reviewRepository;
        protected readonly IMapper _mapper = mapper;

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all reviews", Description = "Returns a list of all reviews.")]
        [SwaggerResponse(StatusCodes.Status200OK, "List of reviews returned", typeof(IEnumerable<ReadReviewDto>))]
        public async Task<ActionResult<IEnumerable<ReadReviewDto>>> GetAll()
        {
            var reviews = await _reviewRepository.GetAll();
            var result = _mapper.Map<IEnumerable<ReadReviewDto>>(reviews);
            return Ok(result);
        }

        [HttpGet("paged")]
        [SwaggerOperation(
            Summary = "Retrieve paged reviews",
            Description = "Returns a paged list of reviews with pagination metadata."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Paged list of reviews returned", typeof(PagedResponseDto<ReadReviewDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid paging parameters")]
        public async Task<ActionResult<object>> GetPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var pagedList = await _reviewRepository.GetPaged(pageNumber, pageSize);
            var metadata = PaginationMetadataFactory.FromPagedList(
                pagedList,
                Url,
                nameof(GetPaged),
                null,
                Request.Scheme
            );
            var result = _mapper.Map<IEnumerable<ReadReviewDto>>(pagedList);
            return Ok(new
            {
                data = result,
                pagination = metadata
            });
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieve a review by ID", Description = "Returns a single review by its unique ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Review found", typeof(ReadReviewDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Review not found")]
        public async Task<ActionResult<ReadReviewDto>> GetById(int id)
        {
            var review = await _reviewRepository.GetById(id);
            if (review == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<ReadReviewDto>(review);
            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new review", Description = "Creates a new review and returns the created entity.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Review created", typeof(ReadReviewDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input")]
        public async Task<ActionResult<CreateReviewDto>> Create([FromBody] CreateReviewDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var review = _mapper.Map<Review>(dto);
            var createdReview = await _reviewRepository.AddNew(review);
            var result = _mapper.Map<ReadReviewDto>(createdReview);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update a review", Description = "Updates an existing review by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Review updated", typeof(ReadReviewDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Review not found")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input")]
        public async Task<IActionResult> Update([FromBody] UpdateReviewDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var review = await _reviewRepository.GetById(dto.Id);
            if (review == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, review);
            var updatedReview = await _reviewRepository.Update(review);
            var result = _mapper.Map<ReadReviewDto>(updatedReview);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a review", Description = "Deletes a review by its unique ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Review deleted", typeof(int))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Review not found")]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _reviewRepository.GetById(id);
            if (review == null)
            {
                return NotFound();
            }
            await _reviewRepository.Delete(review);
            return Ok(id);
        }
    }
}
