using FluentValidation;

namespace MoneyAdministratorBackend.Models.Validators
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(model => model.UserId)
                .NotEmpty().WithMessage("El usuario es obligatorio");

            RuleFor(model => model.EntityId)
                .NotEmpty().WithMessage("El banco emisor es obligatorio");

            RuleFor(model => model.CreditCardBrandId)
                .NotEmpty().WithMessage("La marca del banco emisor es obligatoria");

            RuleFor(model => model.LastFourNumbers)
                .NotEmpty().WithMessage("Los números de la tarjeta son obligatorios")
                .Length(4).WithMessage("Los últimos 4 números no están completos");
        }
    }
}
