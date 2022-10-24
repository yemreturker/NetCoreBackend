using Core.Entities;

namespace Entities.DTOs
{
    public class TableItemDetailDto : IDto
    {
        public int Id { get; set; }
        public string? Table { get; set; }
        public string? Product { get; set; }
        public short Quantity { get; set; }
        public decimal Total { get; set; }
    }
}