using FluentValidation;
using Primeira_Tarefa.Errors;
using Primeira_Tarefa.Payloads.BrandPayloads;

namespace Primeira_Tarefa.Validators.BrandValidators
{
    public class BrandSearchPayloadValidator : AbstractValidator<BrandSearchPayload>
    {
        public BrandSearchPayloadValidator()
        {
            RuleFor(x => x.Description)
                .MaximumLength(30)
                    .WithMessage(ErrorCodes.EM002)
                    .WithErrorCode(nameof(ErrorCodes.EM002))

                .When(x => x.Description?.Length > 0);

            RuleFor(x => x.MainProvider_Name)
                .MaximumLength(150)
                    .WithMessage(ErrorCodes.EM002)
                    .WithErrorCode(nameof(ErrorCodes.EM002))

                .When(x => x.MainProvider_Name?.Length > 0);

        }
    }
}