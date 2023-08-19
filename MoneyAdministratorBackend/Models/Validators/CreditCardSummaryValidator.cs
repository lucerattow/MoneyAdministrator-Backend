using FluentValidation;

namespace MoneyAdministratorBackend.Models.Validators
{
    public class CreditCardSummaryValidator : AbstractValidator<CreditCardSummary>
    {
        public CreditCardSummaryValidator()
        {
            RuleFor(model => model.CreditCardId)
                .NotEmpty().WithMessage("La tarjeta de crédito es obligatorio");

            RuleFor(model => model.TransactionId)
                .NotEmpty().WithMessage("Se debe generar una transacción para este resumen");

            RuleFor(model => model.Period)
                .NotEmpty().WithMessage("La fecha del periodo es obligatoria");

            RuleFor(model => model.Date)
                .NotEmpty().WithMessage("La fecha de emisión es obligatoria");

            RuleFor(model => model.DateExpiration)
                .NotEmpty().WithMessage("La fecha de vencimiento es obligatoria");

            RuleFor(model => model.DateNext)
                .NotEmpty().WithMessage("La fecha del próximo resumen es obligatoria");

            RuleFor(model => model.DateNextExpiration)
                .NotEmpty().WithMessage("La fecha de vencimiento del próximo resumen es obligatoria");

            RuleFor(model => model.TotalArs)
                .NotEmpty().WithMessage("El valor total en ARS es obligatorio");

            RuleFor(model => model.TotalUsd)
                .NotEmpty().WithMessage("El valor total en USD es obligatorio");

            RuleFor(model => model.MinimumPayment)
                .NotEmpty().WithMessage("El valor del pago mínimo es obligatorio");
        }
    }
}
