using Nexalith.Api.Endpoints;
using Nexalith.Example.Application.Features.Categories.Queries.GetByIdCategory;

namespace Nexalith.Example.Api.Endpoints.Categories;

public class GetByIdCategoryEndpoint(string pattern = "/{id:guid}")
    : BaseGetByIdEndpoint<Guid, GetByIdCategoryRequestDto, GetByIdCategoryQuery, GetByIdCategoryQueryResponse,
        GetByIdCategoryResponseDto>(pattern)
{
}