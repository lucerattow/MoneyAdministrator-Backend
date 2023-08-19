using FluentValidation;

namespace MoneyAdministratorBackend.Models.Validators
{
    public class EntityTypeValidator : AbstractValidator<EntityType>
    {
        public EntityTypeValidator()
        {
            RuleFor(model => model.UserId)
                .NotEmpty().WithMessage("El usuario es obligatorio");

            RuleFor(model => model.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .Length(3, 25).WithMessage("El nombre debe tener entre 3 y 25 caracteres");
        }
    }
}
