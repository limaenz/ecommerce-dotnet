namespace Catalog.API.DTOs
{
    public sealed record CreateItemRequest
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public decimal Price { get; init; }
        public Guid CategoryId { get; init; }
    }
}