using Carter;

namespace Nexalith.Example.Api.Endpoints.Categories;

public class CategoryGroupEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGroup("/categories")
            .AddCategoriesEndpoints();
    }
}

public static class CategoryGroupEndpointExtensions
{
    public static RouteGroupBuilder AddCategoriesEndpoints(this RouteGroupBuilder group)
    {
        new CreateCategoryEndpoint().AddRoutes(group);

        new UpdateCategoryEndpoint().AddRoutes(group);

        new DeleteCategoryEndpoint().AddRoutes(group);

        new GetAllCategoriesEndpoint().AddRoutes(group);

        new GetByIdCategoryEndpoint().AddRoutes(group);

        return group;
    }
}