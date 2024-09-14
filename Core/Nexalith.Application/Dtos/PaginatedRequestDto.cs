namespace Nexalith.Application.Dtos;

public record PaginatedRequestDto(int Page = 1, int PageSize = 10)
{
    public int Page { get; } = Page;
    public int PageSize { get; } = PageSize;
}