using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Table : IEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public short Capasity { get; set; }
        public bool Status { get; set; }
        public bool isDeleted { get; set; }
    }
}
