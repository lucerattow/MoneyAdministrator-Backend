using FluentValidation;

namespace MoneyAdministratorBackend.Models.Validators
{
    public class CreditCardBrandValidator : AbstractValidator<CreditCardBrand>
    {
        public CreditCardBrandValidator()
        {
            RuleFor(model => model.Name)
                .NotEmpty().WithMessage("El nombre de la marca es obligatorio")
                .Length(3, 25).WithMessage("El nombre debe tener entre 3 y 25 caracteres");
        }
    }
}
