using Catalog.API.DTOs;
using Catalog.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Endpoints;

public static class CatalogEndpoints
{
    public static void MapCatalogEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("catalog");
        group.MapGet("items", GetItems);
        group.MapPost("items", CreateItem);
        group.MapPost("categories", CreateCategory);
    }

    private static async Task<Ok<List<ItemResponse>>> GetItems(CatalogContext db)
    {
        var items = await db.Items
            .AsNoTracking()
            .Select(x => new ItemResponse()
            {
                Description = x.Description,
                Name = x.Name,
                Price = x.Price
            }).ToListAsync();

        return TypedResults.Ok(items);
    }

    private static async Task<Created<ItemResponse>> CreateItem(
        CreateItemRequest request,
        CatalogContext db)
    {
        var newItem = Item.CreateItem(
            request.Name,
            request.Description,
            request.Price,
            request.CategoryId
        );

        db.Items.Add(newItem);
        await db.SaveChangesAsync();

        var response = ItemResponse.FromEntity(newItem);

        return TypedResults.Created($"/items/{newItem.Id}", response);
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