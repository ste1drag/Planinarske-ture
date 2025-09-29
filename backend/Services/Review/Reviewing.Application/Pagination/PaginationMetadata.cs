
namespace Reviewing.Application.Pagination
{
    public class PaginationMetadata
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public string? PreviousPageUrl { get; set; }
        public string? NextPageUrl { get; set; }
    }
}
