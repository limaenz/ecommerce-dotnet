namespace Catalog.API.Features.Categories.CreateCategory
{
    public sealed record CreateCategoryRequest
    {
        public required string Name { get; init; }
    }
}