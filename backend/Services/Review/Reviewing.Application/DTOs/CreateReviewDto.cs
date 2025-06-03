
namespace Reviewing.Application.DTOs
{
    public class CreateReviewDto : BaseReviewDto
    {
        public int UserId { get; set; }
        public int TourId { get; set; }
        public required String Title { get; set; }
    }
}
