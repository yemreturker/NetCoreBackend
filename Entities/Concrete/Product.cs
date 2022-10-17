using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(240)]
        public string Description { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public bool isDeleted { get; set; }
    }
}
