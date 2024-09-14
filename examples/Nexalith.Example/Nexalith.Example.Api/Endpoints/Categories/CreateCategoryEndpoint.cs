using Nexalith.Api.Endpoints;
using Nexalith.Example.Application.Features.Categories.Commands.CreateCategory;

namespace Nexalith.Example.Api.Endpoints.Categories;

public class CreateCategoryEndpoint(string pattern = "")
    : BaseCreateEndpoint<CreateCategoryRequestDto, CreateCategoryCommand,
        CreateCategoryCommandResponse, CreateCategoryResponseDto, Guid>(pattern)
{
}