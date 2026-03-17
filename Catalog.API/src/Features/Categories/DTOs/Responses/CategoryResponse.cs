using Catalog.API.Features.Shared.Entities;

namespace Catalog.API.Features.Categories.CreateCategory
{
    public sealed record CategoryResponse
    {
        public required string Name { get; init; }

        public static CategoryResponse FromEntity(Category item)
        {
            return new CategoryResponse()
            {
                Name = item.Name,
            };
        }
    }
}