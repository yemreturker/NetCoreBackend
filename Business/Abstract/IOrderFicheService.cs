using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IOrderFicheService
    {
        IDataResult<List<OrderFiche>> GetAll();
        IDataResult<OrderFiche> Get(int id);
        IDataResult<OrderFicheDetailDto> GetOrderFicheDetails(int id);
        IDataResult<OrderFiche> Add(OrderFiche orderFiche);
        IResult Update(OrderFiche orderFiche);
        IResult Delete(int id);
    }
}
