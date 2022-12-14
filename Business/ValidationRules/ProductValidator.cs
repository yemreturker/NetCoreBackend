using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.CategoryId).GreaterThan(0);
            RuleFor(p => p.CategoryId).Must(CheckIfCategoryExists).WithMessage(Messages.CategoryNotFound); ;

            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(p => p.Name).MaximumLength(50);

            RuleFor(p => Convert.ToInt32(p.UnitsInStock)).GreaterThanOrEqualTo(0);

            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(0);
        }

        private bool CheckIfCategoryExists(int arg)
        {
            CategoryManager _db = new CategoryManager(new EfCategoryDal());
            var list = _db.GetAll();
            foreach (var item in list.Data)
            {
                if (item.Id == arg) return true;
            }
            return false;
        }
    }
}