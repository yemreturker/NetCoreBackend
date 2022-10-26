using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.CustomerId).NotEmpty();
            RuleFor(p => p.OrderFicheId).NotEmpty();
            RuleFor(p => p.ProductId).NotEmpty();

            RuleFor(p => p.PaymentTotal).NotEmpty();
            RuleFor(p => p.PaymentTotal).GreaterThanOrEqualTo(0);

            RuleFor(p => p.ProductAmount).NotEmpty();
            RuleFor(p => Convert.ToInt32(p.ProductAmount)).GreaterThan(0);

            RuleFor(p => p).Must(CheckIfValuesCorrect).WithMessage(Messages.SomeInformationInvalid);
        }

        private bool CheckIfValuesCorrect(Payment payment)
        {
            List<bool> result = new List<bool>();

            OrderFicheManager of_db = new OrderFicheManager(new EfOrderFicheDal());
            result.Add(of_db.Get(payment.OrderFicheId).IsSuccess);

            ProductManager pr_db = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            result.Add(pr_db.Get(payment.ProductId).IsSuccess);



            foreach (var item in result)
            {
                if (!item) return false;
            }
            return true;
        }
    }
}
