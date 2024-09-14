using Nexalith.Api.Endpoints;
using Nexalith.Example.Application.Features.Categories.Commands.UpdateCategory;

namespace Nexalith.Example.Api.Endpoints.Categories;

public class UpdateCategoryEndpoint(string pattern = "/{id:guid}")
    : BaseUpdateEndpoint<Guid, UpdateCategoryRequestDto, UpdateCategoryCommand, UpdateCategoryCommandResponse,
        UpdateCategoryResponseDto>(pattern)
{
}