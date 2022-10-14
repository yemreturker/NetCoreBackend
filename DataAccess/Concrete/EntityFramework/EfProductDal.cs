using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, RestaurantContext>, IProductDal
    {
        public ProductDetailDto GetProductDetails(int id)
        {
            using (RestaurantContext context = new RestaurantContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             select new ProductDetailDto
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 Category = c.Name,
                                 UnitsInStock = p.UnitsInStock,
                                 UnitPrice = p.UnitPrice
                             };
                ProductDetailDto? returnItem = result.SingleOrDefault(x => x.Id == id);
                return returnItem != null ? returnItem : null;
            }
        }
    }
}