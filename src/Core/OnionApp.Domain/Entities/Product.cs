using OnionApp.Domain.Entities.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionApp.Domain.Entities
{
    public class Product:BaseEntity<int>
    {
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }

        [NotMapped]
        public decimal? TaxIncludedPrice
        {
            get { return UnitPrice * 1.18m; }
        }

        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
