using Core.Entities;

namespace Entities.DTOs
{
    public class PaymentDetailDto : IDto
    {
        public int Id { get; set; }
        public int OrderFicheId { get; set; }
        public string Customer { get; set; }
        public string Product { get; set; }
        public short Amount { get; set; }
        public decimal Total { get; set; }
    }
}