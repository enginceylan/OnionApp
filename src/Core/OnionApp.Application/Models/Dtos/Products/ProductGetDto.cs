namespace OnionApp.Application.Models.Dtos.Products
{
    public class ProductGetDto
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TaxIncludedPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public string? CategoryName { get; set; }
    }
}
