using Catalog.API.Features.Categories.Entities;

namespace Catalog.API.Features.Categories.DTOs.Responses
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