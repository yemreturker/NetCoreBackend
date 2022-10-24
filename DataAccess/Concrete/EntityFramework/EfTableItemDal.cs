using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTableItemDal : EfEntityRepositoryBase<TableItem, RestaurantContext>, ITableItemDal
    {
        public TableItemDetailDto GetDetails(int id)
        {
            using (RestaurantContext db = new RestaurantContext())
            {
                var result = from t in db.Tables
                             join ti in db.TableItems
                             on t.Id equals ti.TableId
                             select new
                             {
                                 Id = ti.Id,
                                 Table = $"{t.Id} | {t.Name}",
                                 ProductId = ti.ProductId,
                                 Quantity = ti.Quantity,
                             };

                var subResult = from p in db.Products
                                join ti in db.TableItems
                                on p.Id equals ti.ProductId
                                select new
                                {
                                    Id = ti.Id,
                                    Product = $"{p.Id} | {p.Name}",
                                    Total = ti.Quantity * p.UnitPrice
                                };

                var finalResult = from r1 in result
                                  join r2 in subResult
                                  on r1.Id equals r2.Id
                                  select new TableItemDetailDto
                                  {
                                      Id = r1.Id,
                                      Table = r1.Table,
                                      Product = r2.Product,
                                      Quantity = r1.Quantity,
                                      Total = r2.Total
                                  };
                return finalResult.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}