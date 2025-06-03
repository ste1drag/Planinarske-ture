namespace Reviewing.Application.DTOs
{
    public class UpdateReviewDto : BaseReviewDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}
