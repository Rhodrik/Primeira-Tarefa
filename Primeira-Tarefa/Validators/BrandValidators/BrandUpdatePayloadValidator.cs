using FluentValidation;
using Primeira_Tarefa.DataBase;
using Primeira_Tarefa.Payloads.BrandPayloads;

namespace Primeira_Tarefa.Validators.BrandValidators
{
    public class BrandUpdatePayloadValidator : AbstractValidator<BrandUpdatePayload>
    {

        public BrandUpdatePayloadValidator(BrandDataBase brandDataBase)
        {
            RuleFor(x => x.GetId())
                .Must(x => brandDataBase.BrandList.Any(y => y.Id == x))
                    .WithMessage("The id provided has not yet been registered");

            RuleFor(x => x.Description)
                .NotEmpty()
                    .WithMessage("The description field cannot be empty")

                .MaximumLength(30)
                    .WithMessage("The description field cannot exceed 30 characters");

            RuleFor(x => x.MainProvider_Name)
                 .NotEmpty()
                     .WithMessage("The supplier field cannot be empty")

                 .MaximumLength(150)
                     .WithMessage("The supplier field cannot exceed 150 characters");

            RuleFor(x => x.Since)
                .GreaterThan(DateTime.Now)
                    .WithMessage("The opening date cannot exceed the current date");

        }
    }
}
