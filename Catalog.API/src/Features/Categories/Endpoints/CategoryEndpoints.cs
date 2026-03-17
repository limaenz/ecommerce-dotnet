using Catalog.API.Features.Categories.CreateCategory;
using Catalog.API.Features.Shared.Data;
using Catalog.API.Features.Shared.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Features.Categories.Shared;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("catalog");
        group.MapPost("categories", CreateCategory);
    }

    private static async Task<Created<CategoryResponse>> CreateCategory(
        CreateCategoryRequest request,
        CatalogContext db)
    {
        var newCategory = Category.CreateCategory(request.Name);

        db.Categories.Add(newCategory);
        await db.SaveChangesAsync();

        var response = CategoryResponse.FromEntity(newCategory);

        return TypedResults.Created($"/categories/{newCategory.Id}", response);
    }
}