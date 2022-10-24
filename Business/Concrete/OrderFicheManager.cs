using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class OrderFicheManager : IOrderFicheService
    {
        IOrderFicheDal _orderFicheDal;

        public OrderFicheManager(IOrderFicheDal orderFicheDal)
        {
            _orderFicheDal = orderFicheDal;
        }

        public IResult Add(OrderFiche orderFiche)
        {
            _orderFicheDal.Add(orderFiche);
            return new SuccessResult(Messages.OrderFicheAdded);
        }

        public IResult Delete(int id)
        {
            var result = _orderFicheDal.Get(x => x.Id == id);
            if (result != null)
            {
                _orderFicheDal.Delete(result);
                return new SuccessResult(Messages.OrderFicheDeleted);
            }
            return new ErrorResult(Messages.OrderFicheNotFound);
        }

        public IDataResult<OrderFiche> Get(int id)
        {
            var result = _orderFicheDal.Get(x => x.Id == id);
            if (result != null) return new SuccessDataResult<OrderFiche>(result);
            return new ErrorDataResult<OrderFiche>(Messages.OrderFicheNotFound);
        }

        public IDataResult<List<OrderFiche>> GetAll()
        {
            var result = _orderFicheDal.GetAll();
            if (result != null && result.Count > 0)
                return new SuccessDataResult<List<OrderFiche>>(result);
            return new ErrorDataResult<List<OrderFiche>>(Messages.OrderFicheNotFound);
        }

        public IDataResult<OrderFicheDetailDto> GetOrderFicheDetails(int id)
        {
            var result = _orderFicheDal.GetOrderFicheDetails(id);
            if (result is not null) return new SuccessDataResult<OrderFicheDetailDto>(result);
            return new ErrorDataResult<OrderFicheDetailDto>(Messages.OrderFicheNotFound);
        }

        public IResult Update(OrderFiche orderFiche)
        {
            var result = _orderFicheDal.Get(x => x.Id == orderFiche.Id);
            if (result is not null)
            {
                _orderFicheDal.Update(orderFiche);
                return new SuccessResult(Messages.OrderFicheUpdated);
            }
            return new ErrorResult(Messages.OrderFicheNotFound);
        }
    }
}
