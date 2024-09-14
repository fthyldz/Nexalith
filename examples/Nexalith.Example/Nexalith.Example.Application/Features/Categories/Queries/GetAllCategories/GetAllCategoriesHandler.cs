using Microsoft.EntityFrameworkCore;
using Nexalith.Application.Cqrs.Handler;
using Nexalith.Application.Cqrs.Request;
using Nexalith.Application.Cqrs.Response;
using Nexalith.Application.Data;
using Nexalith.Application.Dtos.Request;
using Nexalith.Application.Dtos.Response;
using Nexalith.Example.Application.Features.Categories.Dtos;
using Nexalith.Example.Domain.Entities;

namespace Nexalith.Example.Application.Features.Categories.Queries.GetAllCategories;

public record GetAllCategoriesRequestDto : IBaseRequestDto<GetAllCategoriesResponseDto>;

public record GetAllCategoriesQuery : IQuery<GetAllCategoriesQueryResponse>;

public record GetAllCategoriesQueryResponse(IEnumerable<Category> Data) : IBaseResponse;

public record GetAllCategoriesResponseDto(IEnumerable<CategoryDto> Data) : BaseGetAllResponseDto<CategoryDto>(Data);

public class GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetAllCategoriesQuery, GetAllCategoriesQueryResponse>
{
    public async Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQuery query,
        CancellationToken cancellationToken)
    {
        var categories = await unitOfWork.GetRepository<Category>().Find().ToListAsync(cancellationToken);
        return new GetAllCategoriesQueryResponse(categories);
    }
}