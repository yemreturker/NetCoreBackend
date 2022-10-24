using Core.Entities;

namespace Entities.DTOs
{
    public class OrderFicheDetailDto : IDto
    {
        public int Id { get; set; }
        public string Table { get; set; }
        public decimal Total { get; set; }
        public string Date { get; set; }
    }
}
