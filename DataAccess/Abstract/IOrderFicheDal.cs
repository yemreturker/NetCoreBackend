using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IOrderFicheDal : IEntityRepository<OrderFiche>
    {
        OrderFicheDetailDto GetOrderFicheDetails(int id);
    }
}
