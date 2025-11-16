using OnionApp.Domain.Entities.Abstraction;

namespace OnionApp.Domain.Entities
{
    public class Order:BaseEntity<int>
    {
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public decimal? Freight { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAddress { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
