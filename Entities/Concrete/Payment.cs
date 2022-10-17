using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int OrderFicheId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public short ProductAmount { get; set; }
        public decimal PaymentTotal { get; set; }
    }
}
