using Reviewing.Application.Pagination;

public class PagedResponseDto<T>
{
    public IEnumerable<T> Data { get; set; } = [];
    public PaginationMetadata Pagination { get; set; } = default!;
}