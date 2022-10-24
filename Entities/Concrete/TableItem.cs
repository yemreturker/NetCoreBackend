using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class TableItem : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int TableId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public bool isDeleted { get; set; }
    }
}