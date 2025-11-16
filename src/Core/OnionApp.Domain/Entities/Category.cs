using OnionApp.Domain.Entities.Abstraction;

namespace OnionApp.Domain.Entities
{
    public class Category : BaseEntity<int>
    {
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        public List<Product>? Products { get; set; }
    }
}
