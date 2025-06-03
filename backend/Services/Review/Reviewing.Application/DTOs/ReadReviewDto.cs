namespace Reviewing.Application.DTOs
{
    public class ReadReviewDto : BaseReviewDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TourId { get; set; }
        public required string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
