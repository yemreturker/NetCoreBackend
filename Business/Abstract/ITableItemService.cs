using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ITableItemService
    {
        IDataResult<List<TableItem>> GetAll();
        IDataResult<List<TableItem>> GetByTableId(int TableId);
        IDataResult<TableItemDetailDto> GetDetails(int id);
        IResult Add(TableItem tableItem);
        IResult Delete(int id);
        IResult Update(TableItem tableItem);
    }
}