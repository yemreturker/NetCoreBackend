using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class PaymentType : IEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Type { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
