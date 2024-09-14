using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nexalith.Application.Cqrs.Handler;
using Nexalith.Application.Cqrs.Request;
using Nexalith.Application.Cqrs.Response;
using Nexalith.Application.Data;
using Nexalith.Application.Dtos.Request;
using Nexalith.Application.Dtos.Response;
using Nexalith.Application.Exceptions;
using Nexalith.Example.Application.Features.Categories.Dtos;
using Nexalith.Example.Domain.Entities;
using Nexalith.Example.Domain.ValueObjects;

namespace Nexalith.Example.Application.Features.Categories.Queries.GetByIdCategory;

public record GetByIdCategoryRequestDto(Guid Id) : BaseGetByIdRequestDto<Guid, GetByIdCategoryResponseDto>(Id);

public record GetByIdCategoryQuery(CategoryId Id) : IQuery<GetByIdCategoryQueryResponse>;

public record GetByIdCategoryQueryResponse(Category Data) : IBaseResponse;

public record GetByIdCategoryResponseDto(CategoryDto Data) : BaseGetByIdResponseDto<CategoryDto>(Data);

public class GetByIdCategoryQueryValidator : AbstractValidator<GetByIdCategoryQuery>
{
    public GetByIdCategoryQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

public class GetByIdCategoryHandlerQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetByIdCategoryQuery, GetByIdCategoryQueryResponse>
{
    public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQuery query,
        CancellationToken cancellationToken)
    {
        var category = await unitOfWork.GetRepository<Category>().Find(category => category.Id == query.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (category is null) throw new NotFoundException(nameof(Category), query.Id.Value);

        return new GetByIdCategoryQueryResponse(category);
    }
}