using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoneyAdministratorBackend.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoneyAdministratorBackend.Models.Validators
{
    public class CreditCardSummaryDetailValidator : AbstractValidator<CreditCardSummaryDetail>
    {
        public CreditCardSummaryDetailValidator()
        {
            RuleFor(model => model.CreditCardSummaryId)
                .NotEmpty().WithMessage("El resumen principal es obligatorio");

            RuleFor(model => model.Type)
                .NotEmpty().WithMessage("El tipo de detalle es obligatorio");

            RuleFor(model => model.Date)
                .NotEmpty().WithMessage("La fecha del detalle es obligatoria");
        }
    }
}
