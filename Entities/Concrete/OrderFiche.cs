using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class OrderFiche : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int TableId { get; set; }
        public decimal TotalPrice { get; set; }
        [MaxLength(30)]
        public string Date { get; set; }
    }
}
