namespace Reviewing.Application.DTOs
{
    public abstract class BaseReviewDto
    {
        public string? Comment { get; set; }
        public int? Difficulty { get; set; }
        public int? Score { get; set; } 
    }
}
