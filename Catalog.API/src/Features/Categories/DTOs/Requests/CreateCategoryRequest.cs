namespace Catalog.API.Features.Categories.DTOs.Requests
{
    public sealed record CreateCategoryRequest
    {
        public required string Name { get; init; }
    }
}