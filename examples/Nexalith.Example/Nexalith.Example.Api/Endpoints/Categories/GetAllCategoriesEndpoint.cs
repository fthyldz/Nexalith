using Nexalith.Api.Endpoints;
using Nexalith.Example.Application.Features.Categories.Dtos;
using Nexalith.Example.Application.Features.Categories.Queries.GetAllCategories;

namespace Nexalith.Example.Api.Endpoints.Categories;

public class GetAllCategoriesEndpoint(string pattern = "")
    : BaseGetAllEndpoint<GetAllCategoriesRequestDto, GetAllCategoriesQuery, GetAllCategoriesQueryResponse,
        GetAllCategoriesResponseDto, CategoryDto>(pattern)
{
}