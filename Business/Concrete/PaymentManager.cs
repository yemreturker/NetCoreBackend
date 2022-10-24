using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentAdded);
        }

        public IResult Delete(int id)
        {
            var result = _paymentDal.Get(x => x.Id == id);
            if (result != null)
            {
                _paymentDal.Delete(result);
                return new SuccessResult(Messages.PaymentDeleted);
            }
            return new ErrorResult(Messages.PaymentNotFound);
        }

        public IDataResult<Payment> Get(int id)
        {
            var result = _paymentDal.Get(x => x.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Payment>(result);
            }
            return new ErrorDataResult<Payment>(Messages.PaymentNotFound);
        }

        public IDataResult<List<Payment>> GetAll()
        {
            var result = _paymentDal.GetAll();
            if (result.Count > 0 && result != null)
            {
                return new SuccessDataResult<List<Payment>>(result);
            }
            return new ErrorDataResult<List<Payment>>(Messages.PaymentNotFound);
        }

        public IDataResult<List<Payment>> GetPaymentByOrderFicheId(int orderFicheId)
        {
            var result = _paymentDal.GetAll(x => x.OrderFicheId == orderFicheId);
            if (result.Count > 0 && result != null)
            {
                return new SuccessDataResult<List<Payment>> (result);
            }
            return new ErrorDataResult<List<Payment>>(Messages.PaymentNotFound);
        }

        public IDataResult<PaymentDetailDto> GetPaymentDetails(int id)
        {
            var result = _paymentDal.GetPaymentDetails(id);
            if (result != null)
            {
                return new SuccessDataResult<PaymentDetailDto>(result);
            }
            return new ErrorDataResult<PaymentDetailDto>(Messages.PaymentNotFound);
        }

        public IResult Update(Payment payment)
        {
            var result = _paymentDal.Get(x => x.Id == payment.Id);
            if (result != null)
            {
                _paymentDal.Update(payment);
                return new SuccessResult(Messages.PaymentUpdated);
            }
            return new ErrorResult(Messages.PaymentNotFound);
        }
    }
}