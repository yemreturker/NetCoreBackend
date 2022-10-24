using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITableService
    {
        IDataResult<List<Table>> GetAll();
        IDataResult<Table> Get(int id);
        IResult Add(Table table);
        IResult Update(Table table);
        IResult Delete(int id);
    }
}
