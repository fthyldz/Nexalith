using Microsoft.EntityFrameworkCore;
using Nexalith.Application.Cqrs.Handler;
using Nexalith.Application.Cqrs.Request;
using Nexalith.Application.Cqrs.Response;
using Nexalith.Application.Data;
using Nexalith.Application.Dtos.Request;
using Nexalith.Application.Dtos.Response;
using Nexalith.Application.Exceptions;
using Nexalith.Example.Domain.Entities;
using Nexalith.Example.Domain.ValueObjects;

namespace Nexalith.Example.Application.Features.Categories.Commands.DeleteCategory;

public record DeleteCategoryRequestDto(Guid Id) : BaseDeleteRequestDto<Guid, DeleteCategoryResponseDto>(Id);

public record DeleteCategoryCommand(CategoryId Id) : ICommand<DeleteCategoryCommandResponse>;

public record DeleteCategoryCommandResponse(bool IsSuccess) : IBaseResponse;

public record DeleteCategoryResponseDto(bool IsSuccess) : IBaseResponseDto;

public class DeleteCategoryHandlerQueryHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
{
    public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand command,
        CancellationToken cancellationToken)
    {
        var categoryRepository = unitOfWork.GetRepository<Category>();

        var category = await categoryRepository.Find(category => category.Id == command.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (category is null) throw new NotFoundException(nameof(Category), command.Id.Value);

        categoryRepository.Delete(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteCategoryCommandResponse(true);
    }
}