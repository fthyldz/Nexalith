using Nexalith.Api.Endpoints;
using Nexalith.Example.Application.Features.Categories.Commands.DeleteCategory;

namespace Nexalith.Example.Api.Endpoints.Categories;

public class DeleteCategoryEndpoint(string pattern = "/{id:guid}")
    : BaseDeleteEndpoint<Guid, DeleteCategoryRequestDto, DeleteCategoryCommand, DeleteCategoryCommandResponse,
        DeleteCategoryResponseDto>(pattern)
{
}