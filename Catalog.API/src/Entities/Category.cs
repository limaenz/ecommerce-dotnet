namespace Catalog.API.Entities
{
    public sealed class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private Category(string name)
        {
            Name = name;
            Id = Guid.CreateVersion7();
        }

        public static Category CreateCategory(string name)
        {
            return new Category(name);
        }
    }
}