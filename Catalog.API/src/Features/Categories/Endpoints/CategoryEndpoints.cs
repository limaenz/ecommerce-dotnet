using Catalog.API.Features.Categories.DTOs.Requests;
using Catalog.API.Features.Categories.DTOs.Responses;
using Catalog.API.Features.Categories.Entities;
using Catalog.API.Features.Shared.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Features.Categories.Endpoints;

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