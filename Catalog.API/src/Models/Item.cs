namespace Catalog.API.Models
{
    public sealed class Item
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category? Category { get; private set; }

        private Item(string name, string description, decimal price, Guid categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            Id = Guid.CreateVersion7();
        }

        public static Item CreateItem(string name, string description, decimal price, Guid categoryId)
        {
            return new Item(name, description, price, categoryId);
        }
    }
}