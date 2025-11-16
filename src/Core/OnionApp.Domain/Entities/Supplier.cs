using OnionApp.Domain.Entities.Abstraction;

namespace OnionApp.Domain.Entities
{
    public class Supplier:BaseEntity<int>
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public List<Product>? Products { get; set; }
    }
}
