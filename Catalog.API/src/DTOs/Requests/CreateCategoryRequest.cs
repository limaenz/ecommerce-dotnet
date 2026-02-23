namespace Catalog.API.DTOs.Requests
{
    public sealed record CreateCategoryRequest
    {
        public required string Name { get; init; }
    }
}