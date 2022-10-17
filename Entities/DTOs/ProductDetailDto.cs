using Core.Entities;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
