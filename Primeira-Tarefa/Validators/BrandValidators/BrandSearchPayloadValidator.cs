using FluentValidation;
using Primeira_Tarefa.DTO;
using Primeira_Tarefa.Payloads.BrandPayloads;

namespace Primeira_Tarefa.Validators.BrandValidators
{
    public class BrandSearchPayloadValidator : AbstractValidator<BrandSearchPayload>
    {
        public BrandSearchPayloadValidator()
        {
            RuleFor(x => x.Description)
                .MaximumLength(30)
                    .WithMessage("The Description field cannot exceed 30 characters");

            RuleFor(x => x.MainProvider_Name)
                .MaximumLength(150)
                    .WithMessage("The Main Provider Name field cannot exceed 150 characters");

        }
    }
}