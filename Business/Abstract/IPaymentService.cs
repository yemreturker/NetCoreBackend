using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IDataResult<List<Payment>> GetAll();
        IDataResult<Payment> Get(int id);
        IDataResult<PaymentDetailDto> GetPaymentDetails(int id);
        IDataResult<List<Payment>> GetPaymentByOrderFicheId(int orderFicheId);
        IResult Add(Payment payment);
        IResult Update(Payment payment);
        IResult Delete(int id);
    }
}