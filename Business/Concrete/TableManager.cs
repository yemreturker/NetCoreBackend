using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TableManager : ITableService
    {
        ITableDal _tableDal;
        public TableManager(ITableDal tableDal)
        {
            this._tableDal = tableDal;
        }

        [ValidationAspect(typeof(TableValidator))]
        public IResult Add(Table table)
        {
            _tableDal.Add(table);
            return new SuccessResult(Messages.TableAdded);
        }

        public IResult Delete(int id)
        {
            Table table = _tableDal.Get(x => x.Id == id);
            if (table != null)
            {
                _tableDal.Delete(table);
                return new SuccessResult(Messages.TableDeleted);
            }
            return new ErrorResult(Messages.TableNotFound);
        }

        public IDataResult<Table> Get(int id)
        {
            Table table = _tableDal.Get(x => x.Id == id);
            if (table != null)
            {
                return new SuccessDataResult<Table>(table);
            }
            return new ErrorDataResult<Table>(Messages.TableNotFound);
        }

        public IDataResult<List<Table>> GetAll()
        {
            List<Table> tables = _tableDal.GetAll();
            if (tables.Count > 0)
            {
                return new SuccessDataResult<List<Table>>(tables);
            }
            return new ErrorDataResult<List<Table>>(Messages.TableNotFound);
        }

        public IResult Update(Table table)
        {
            Table tableFDb = _tableDal.Get(x => x.Id == table.Id);
            if (tableFDb != null)
            {
                _tableDal.Update(table);
                return new SuccessResult(Messages.TableUpdated);
            }
            return new ErrorResult(Messages.TableNotFound);
        }
    }
}
