using Catalog.API.Models;

namespace Catalog.API.DTOs
{
    public sealed record ItemResponse
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public decimal Price { get; init; }

        public static ItemResponse FromEntity(Item item)
        {
            return new ItemResponse()
            {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price
            };
        }
    }
}