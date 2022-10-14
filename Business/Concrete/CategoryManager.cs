using Business.Abstract;
using Business.BusinessAspects.Autofac.Validation;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categories;

        public CategoryManager(ICategoryDal categories)
        {
            _categories = categories;
        }


        [SecuredOperation("admin,category.add")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run(CheckIfNameAlreadyExists(category.CategoryName));
            if (result != null) return result;
            _categories.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }


        [SecuredOperation("admin,category.add")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(Category category)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryNotExists(category.CategoryId));
            if (result != null) return result;
            _categories.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }


        [SecuredOperation("admin,category.delete")]
        public IResult Delete(int id)
        {
            var result = BusinessRules.Run(CheckIfCategoryNotExists(id));
            if (result != null) return result;
            _categories.Delete(_categories.Get(c => c.CategoryId == id));
            return new SuccessResult(Messages.CategoryDeleted);
        }
        public IDataResult<Category> GetById(int id)
        {
            var result = _categories.Get(c => c.CategoryId == id);
            if (result != null) return new SuccessDataResult<Category>(result);
            return new ErrorDataResult<Category>(Messages.CategoryNotFound);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categories.GetAll());
        }

        public IResult CheckIfNameAlreadyExists(string name)
        {
            var result = _categories.GetAll(c => c.CategoryName == name).Any();
            if (result) return new ErrorResult(Messages.NameAlreadyExists);
            return new SuccessResult();
        }
        public IResult CheckIfCategoryNotExists(int id)
        {
            var result = _categories.Get(c => c.CategoryId == id);
            if (result == null) return new ErrorResult(Messages.CategoryNotFound);
            return new SuccessResult();
        }

    }
}
