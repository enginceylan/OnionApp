using OnionApp.Domain.Entities.Abstraction;

namespace OnionApp.Domain.Entities
{
    public class OrderDetail:BaseEntity<object>
    {
        //Burada BaseEntity<object> kullanıyoruz çünkü Id kullanılmayacak ve Entity Framework Core'da composite key kullanmak için Fluent API ile tanımlama yapılacak
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? Quantity { get; set; }
        public float? Discount { get; set; }

        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}
