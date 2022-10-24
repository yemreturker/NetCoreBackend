using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, RestaurantContext>, IPaymentDal
    {
        public PaymentDetailDto GetPaymentDetails(int id)
        {
            using (RestaurantContext db = new RestaurantContext())
            {
                var subResult1 = from payment in db.Payments
                                 join customer in db.Customers
                                 on payment.CustomerId equals customer.Id
                                 select new
                                 {
                                     Id = payment.Id,
                                     OrderFicheId = payment.OrderFicheId,
                                     Customer = $"{customer.Id} | {customer.Name}",
                                     ProductId = payment.ProductId,
                                     Amount = payment.ProductAmount,
                                     Total = payment.PaymentTotal
                                 };

                var subResult2 = from payment in db.Payments
                                 join product in db.Products
                                 on payment.ProductId equals product.Id
                                 select new
                                 {
                                     Id = payment.Id,
                                     Product = $"{product.Id} | {product.Name}"
                                 };

                var result1 = subResult1.SingleOrDefault(x => x.Id == id);
                var result2 = subResult2.SingleOrDefault(x => x.Id == id);
                return new PaymentDetailDto
                {
                    Id = result1.Id,
                    OrderFicheId = result1.OrderFicheId,
                    Customer = result1.Customer,
                    Product = result2.Product,
                    Amount = result1.Amount,
                    Total = result1.Total
                };
            }
        }
    }
}