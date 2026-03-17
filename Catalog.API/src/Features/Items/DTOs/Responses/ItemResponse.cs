using Catalog.API.Features.Shared.Entities;

namespace Catalog.API.Features.Items.Shared
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