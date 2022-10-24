using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class TableItemManager : ITableItemService
    {
        ITableItemDal _tableItemDal;

        public TableItemManager(ITableItemDal tableItemDal)
        {
            _tableItemDal = tableItemDal;
        }

        public IResult Add(TableItem tableItem)
        {
            var result = _tableItemDal.Get(x => x.ProductId == tableItem.ProductId && !x.isDeleted && x.TableId == tableItem.TableId);
            if (result != null)
            {
                result.Quantity += tableItem.Quantity;
                _tableItemDal.Update(result);
                return new SuccessResult(Messages.TableItemAdded);
            }
            _tableItemDal.Add(tableItem);
            return new SuccessResult(Messages.TableItemAdded);
        }

        public IResult Delete(int id)
        {
            var result = _tableItemDal.Get(x => x.Id == id);
            if (result is not null)
            {
                _tableItemDal.Delete(result);
                return new SuccessResult(Messages.TableItemDeleted);
            }
            return new ErrorResult(Messages.TableItemNotFound);
        }

        public IDataResult<List<TableItem>> GetAll()
        {
            var result = _tableItemDal.GetAll();
            if (result is not null) return new SuccessDataResult<List<TableItem>>(result);
            return new ErrorDataResult<List<TableItem>>(Messages.TableItemNotFound); ;
        }

        public IDataResult<List<TableItem>> GetByTableId(int TableId)
        {
            var result = _tableItemDal.GetAll(x => x.TableId == TableId && !x.isDeleted);
            if (result is not null) return new SuccessDataResult<List<TableItem>>(result);
            return new ErrorDataResult<List<TableItem>>(Messages.TableItemNotFound);
        }

        public IDataResult<TableItemDetailDto> GetDetails(int id)
        {
            var result = _tableItemDal.GetDetails(id);
            if (result is not null) return new SuccessDataResult<TableItemDetailDto>(result);
            return new ErrorDataResult<TableItemDetailDto>(Messages.TableItemNotFound);
        }

        public IResult Update(TableItem tableItem)
        {
            var result = _tableItemDal.Get(x => x.Id == tableItem.Id);
            if (result is not null)
            {
                if (tableItem.Quantity < result.Quantity)
                {
                    result.Quantity -= tableItem.Quantity;
                    _tableItemDal.Update(result);
                    return new SuccessResult(Messages.TableItemUpdated);
                }
                else
                {
                    result.isDeleted = true;
                    result.Quantity = 0;
                    _tableItemDal.Update(result);
                    return new SuccessResult(Messages.TableItemDeleted);
                }
            }
            return new ErrorResult(Messages.TableItemNotFound);
        }
    }
}