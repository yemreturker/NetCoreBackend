using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ITableItemDal : IEntityRepository<TableItem>
    {
        TableItemDetailDto GetDetails(int id);
    }
}
