using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> Get(int id);
        IDataResult<List<Product>> ByCategoryId(int id);
        IDataResult<ProductDetailDto> GetProductDetails(int id);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(int id);
    }
}