using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderFicheDal : EfEntityRepositoryBase<OrderFiche, RestaurantContext>, IOrderFicheDal
    {
        public OrderFicheDetailDto GetOrderFicheDetails(int id)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                var result = from of in context.OrderFiches
                             join t in context.Tables
                             on of.TableId equals t.Id
                             select new OrderFicheDetailDto
                             {
                                 Id = of.Id,
                                 Table = $"{t.Id} | {t.Name}",
                                 Total = of.TotalPrice,
                                 Date = of.Date
                             };
                return result.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
