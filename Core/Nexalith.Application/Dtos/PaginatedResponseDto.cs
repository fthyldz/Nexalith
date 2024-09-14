namespace Nexalith.Application.Dtos;

public record PaginatedResponseDto<TData>(
    bool IsSuccess,
    long TotalItems,
    long CurrentPage = 1,
    long PageSize = 10,
    IEnumerable<TData>? Data = null
) where TData : class
{
    public bool IsSuccess { get; } = IsSuccess;
    public IEnumerable<TData>? Data { get; } = Data;
    public long CurrentPage { get; } = CurrentPage;
    public long PageSize { get; } = PageSize;
    public long TotalItems { get; } = TotalItems;
    public long TotalPages { get; } = (long)Math.Ceiling((double)TotalItems / PageSize);
    public bool HasNextPage => CurrentPage < TotalPages;
    public bool HasPreviousPage => CurrentPage > 1;
}