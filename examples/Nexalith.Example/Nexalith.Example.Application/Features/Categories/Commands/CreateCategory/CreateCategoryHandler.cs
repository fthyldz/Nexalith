using Mapster;
using Nexalith.Application.Cqrs.Handler;
using Nexalith.Application.Cqrs.Request;
using Nexalith.Application.Cqrs.Response;
using Nexalith.Application.Data;
using Nexalith.Application.Dtos.Request;
using Nexalith.Application.Dtos.Response;
using Nexalith.Example.Domain.Entities;
using Nexalith.Example.Domain.ValueObjects;

namespace Nexalith.Example.Application.Features.Categories.Commands.CreateCategory;

public record CreateCategoryRequestDto(string Name) : IBaseRequestDto<CreateCategoryResponseDto>;

public record CreateCategoryCommand(string Name) : ICommand<CreateCategoryCommandResponse>;

public record CreateCategoryCommandResponse(CategoryId Id) : IBaseResponse;

public record CreateCategoryResponseDto(Guid Id) : IBaseResponseDto;

public class CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        var categoryRepository = unitOfWork.GetRepository<Category>();

        var category = command.Adapt<Category>();

        categoryRepository.Add(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateCategoryCommandResponse(category.Id);
    }
}