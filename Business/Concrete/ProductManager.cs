using Business.Abstract;
using Business.BusinessAspects.Autofac.Validation;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }


        [SecuredOperation("admin,moderator,product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(
                CheckIfProductNameExists(product.Name));
            if (result != null) return result;
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }


        [SecuredOperation("admin,moderator,product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            if ((_productDal.Get(p => p.Id == product.Id)) == null) return new ErrorResult(Messages.ProductNotFound);
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        [SecuredOperation("admin,moderator,product.delete")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(int id)
        {
            var product = _productDal.Get(p => p.Id == id);
            if (product != null)
            {
                _productDal.Update(new Product()
                {
                    Id = product.Id,
                    UnitPrice = product.UnitPrice,
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    isDeleted = true,
                    Name = product.Name,
                    UnitsInStock = product.UnitsInStock,
                });
                return new SuccessResult(Messages.ProductDeleted);
            }
            return new ErrorResult(Messages.ProductNotFound);
        }

        [LogAspect(typeof(FileLogger))]
        public IDataResult<ProductDetailDto> GetProductDetails(int id)
        {
            if (_productDal.Get(x => x.Id == id) == null)
                return new ErrorDataResult<ProductDetailDto>(Messages.ProductNotFound);
            return new SuccessDataResult<ProductDetailDto>(_productDal.GetProductDetails(id));
        }

        public IDataResult<List<Product>> ByCategoryId(int id)
        {
            if ((_productDal.GetAll(p => p.CategoryId == id)).IsNullOrEmpty())
                return new ErrorDataResult<List<Product>>(Messages.CategoryNotFoundOrEmpty);
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Product> Get(int id)
        {
            if ((_productDal.Get(p => p.Id == id)) == null)
                return new ErrorDataResult<Product>(Messages.ProductNotFound);
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == id && p.isDeleted == false));
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if ((_productDal.GetAll()).Count <= 0)
                return new ErrorDataResult<List<Product>>(Messages.ProductNotFound);
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.isDeleted == false));
        }

        // Business requirements // iş kodları
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.Name == productName && !p.isDeleted).Any();
            if (result) return new ErrorResult(Messages.NameAlreadyExists);
            return new SuccessResult();
        }
    }
}