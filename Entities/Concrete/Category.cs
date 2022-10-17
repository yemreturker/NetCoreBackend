using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
