using FluentValidation;
using Primeira_Tarefa.Errors;
using Primeira_Tarefa.Payloads.BrandPayloads;

namespace Primeira_Tarefa.Validators.BrandValidators
{
    public class BrandInsertPayloadValidator : AbstractValidator<BrandInsertPayload>
    {
        public BrandInsertPayloadValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                    .WithMessage(ErrorCodes.EM001)
                    .WithErrorCode(nameof(ErrorCodes.EM001))
                .MaximumLength(30)
                    .WithMessage(ErrorCodes.EM002)
                    .WithErrorCode(nameof(ErrorCodes.EM002));

            RuleFor(x => x.MainProvider_Name)
                .MaximumLength(150)
                    .WithMessage(ErrorCodes.EM002)
                    .WithErrorCode(nameof(ErrorCodes.EM002))
                .WithName("Main Provider Name");

            RuleFor(x => x.Since)
                .LessThan(DateTime.UtcNow)
                    .WithMessage(ErrorCodes.EM003)
                    .WithErrorCode(nameof(ErrorCodes.EM003))
                .WithName("Opening Date");
        }
    }
}
