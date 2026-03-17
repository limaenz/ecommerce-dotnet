using Catalog.API.Features.Items.Shared;
using Catalog.API.Features.Shared.Data;
using Catalog.API.Features.Shared.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Features.Items.CreateItem;

public static class ItemEndpoints
{
    public static void MapItemEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("catalog");
        group.MapGet("items", GetItems);
        group.MapPost("items", CreateItem);
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
}