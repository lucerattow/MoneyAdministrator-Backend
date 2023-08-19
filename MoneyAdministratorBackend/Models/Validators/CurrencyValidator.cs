using FluentValidation;

namespace MoneyAdministratorBackend.Models.Validators
{
    public class CurrencyValidator : AbstractValidator<Currency>
    {
        public CurrencyValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .Length(3).WithMessage("El nombre debe tener 3 caracteres");
        }
    }
}
