using FluentValidation;
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

namespace Nexalith.Example.Application.Features.Categories.Commands.UpdateCategory;

public record UpdateCategoryRequestDto(Guid Id, string Name)
    : BaseUpdateRequestDto<Guid, UpdateCategoryResponseDto>(Id);

public record UpdateCategoryCommand(CategoryId Id, string Name) : ICommand<UpdateCategoryCommandResponse>;

public record UpdateCategoryCommandResponse(bool IsSuccess) : IBaseResponse;

public record UpdateCategoryResponseDto(bool IsSuccess) : BaseUpdateResponseDto(IsSuccess);

public class UpdateCategoryRequestDtoValidator : AbstractValidator<UpdateCategoryRequestDto>
{
    public UpdateCategoryRequestDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}

public class UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
{
    public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand command,
        CancellationToken cancellationToken)
    {
        var categoryRepository = unitOfWork.GetRepository<Category>();

        var category = await categoryRepository.Find(category => category.Id == command.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (category is null) throw new NotFoundException(nameof(Category), command.Id.Value);

        category.Update(command.Name);

        categoryRepository.Update(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateCategoryCommandResponse(true);
    }
}