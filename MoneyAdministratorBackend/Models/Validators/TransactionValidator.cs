using FluentValidation;

namespace MoneyAdministratorBackend.Models.Validators
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(model => model.UserId)
                .NotEmpty().WithMessage("El usuario es obligatorio");

            RuleFor(model => model.EntityId)
                .NotEmpty().WithMessage("La entidad es obligatoria");

            RuleFor(model => model.CurrencyId)
                .NotEmpty().WithMessage("La moneda es obligatoria");

            RuleFor(model => model.TransactionType)
                .NotEmpty().WithMessage("La moneda es obligatoria");
        }
    }
}
