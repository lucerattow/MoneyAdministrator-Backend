using FluentValidation;

namespace MoneyAdministratorBackend.Models.Validators
{
    public class SalaryValidator : AbstractValidator<Salary>
    {
        public SalaryValidator()
        {
            RuleFor(model => model.UserId)
                .NotEmpty().WithMessage("El usuario es obligatorio");

            RuleFor(model => model.Date)
                .NotEmpty().WithMessage("La fecha es obligatoria");

            RuleFor(model => model.CurrencyId)
                .NotEmpty().WithMessage("La moneda es obligatoria");
        }
    }
}
