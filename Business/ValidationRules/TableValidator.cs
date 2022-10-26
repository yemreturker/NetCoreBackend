using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class TableValidator : AbstractValidator<Table>
    {
        public TableValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Name).MinimumLength(2);
            RuleFor(t => t.Name).Must(CheckIfNameExists).WithMessage(Messages.NameAlreadyExists);

            RuleFor(t => t.Capasity).NotEmpty();
            RuleFor(t => Convert.ToInt32(t.Capasity)).GreaterThan(0);

            RuleFor(t => t.Status).NotEmpty();
            RuleFor(t => t.isDeleted).NotEqual(true);
        }


        private bool CheckIfNameExists(string tableName)
        {
            TableManager db = new TableManager(new EfTableDal());
            var list = db.GetAll();
            foreach (var item in list.Data)
            {
                if (item.Name == tableName) return false;
            }
            return true;
        }
    }
}
