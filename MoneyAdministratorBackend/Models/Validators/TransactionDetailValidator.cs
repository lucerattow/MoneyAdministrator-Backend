using FluentValidation;

namespace MoneyAdministratorBackend.Models.Validators
{
    public class TransactionDetailValidator : AbstractValidator<TransactionDetail>
    {
        public TransactionDetailValidator()
        {
            RuleFor(model => model.TransactionId)
                .NotEmpty().WithMessage("La transacción es obligatoria");

            RuleFor(model => model.Date)
                .NotEmpty().WithMessage("La fecha es obligatoria");

            RuleFor(model => model.EndDate)
                .NotEmpty().WithMessage("La fecha final es obligatoria");

            RuleFor(model => model.Amount)
                .NotEmpty().WithMessage("El monto es obligatoria");
        }
    }
}
