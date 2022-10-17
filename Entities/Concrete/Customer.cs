using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(12)]
        public string Phone { get; set; }
        [MaxLength(40)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
