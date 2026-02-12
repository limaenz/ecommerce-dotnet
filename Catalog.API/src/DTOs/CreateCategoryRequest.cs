namespace Catalog.API.DTOs
{
    public sealed record CreateCategoryRequest
    {
        public required string Name { get; init; }
    }
}