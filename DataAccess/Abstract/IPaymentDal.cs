using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IPaymentDal : IEntityRepository<Payment>
    {
        PaymentDetailDto GetPaymentDetails(int id);
    }
}
