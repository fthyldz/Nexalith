using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Nexalith.Example.Application.Features.Categories.Commands.CreateCategory;
using Nexalith.Example.Application.Features.Categories.Dtos;
using Nexalith.Example.Application.Features.Categories.Queries.GetAllCategories;
using Nexalith.Example.Domain.Entities;
using Nexalith.Example.Domain.ValueObjects;

namespace Nexalith.Example.Application.Features.Categories.CategoryMappings;

public static class CategoryMapping
{
    public static void RegisterCategoryMappings(this IServiceCollection services)
    {
        TypeAdapterConfig<Guid, CategoryId>.NewConfig()
            .ConstructUsing(dest => new CategoryId(dest));

        TypeAdapterConfig<CategoryId, Guid>.NewConfig()
            .Map(dest => dest, src => src.Value);

        TypeAdapterConfig<Category, CategoryDto>.NewConfig()
            .ConstructUsing(dest => new CategoryDto(dest.Id.Value, dest.Name));

        TypeAdapterConfig<GetAllCategoriesRequestDto, GetAllCategoriesQuery>.NewConfig();

        TypeAdapterConfig<CreateCategoryCommand, Category>.NewConfig()
            .ConstructUsing(dest => new Category(new CategoryId(Guid.NewGuid()), dest.Name));

        TypeAdapterConfig<CreateCategoryCommandResponse, CreateCategoryResponseDto>.NewConfig()
            .ConstructUsing(dest => new CreateCategoryResponseDto(dest.Id.Value));
    }
}