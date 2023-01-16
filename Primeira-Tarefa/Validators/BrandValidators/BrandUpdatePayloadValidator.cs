using FluentValidation;
using Primeira_Tarefa.Errors;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Payloads.BrandPayloads;
using Primeira_Tarefa.Repository;

namespace Primeira_Tarefa.Validators.BrandValidators
{
    public class BrandUpdatePayloadValidator : AbstractValidator<BrandUpdatePayload>
    {

        public BrandUpdatePayloadValidator(IBrandRepository ibrandRepository)
        {
            RuleFor(x => x.GetId())
                .Must(x => x > 0)
                   .WithMessage(ErrorCodes.EM001)
                   .WithErrorCode(nameof(ErrorCodes.EM001))
                .MustAsync(async (x, token) => await ibrandRepository.IdExist(x))
                   .WithMessage(ErrorCodes.EM004)
                   .WithErrorCode(nameof(ErrorCodes.EM004));

            RuleFor(x => x.Description)
                .NotEmpty()
                    .WithMessage(ErrorCodes.EM001)
                    .WithErrorCode(nameof(ErrorCodes.EM001))      
                    .WithMessage(ErrorCodes.EM002)
                    .WithErrorCode(nameof(ErrorCodes.EM002));

            RuleFor(x => x.MainProvider_Name)
                 .MaximumLength(150)
                     .WithMessage(ErrorCodes.EM002)
                    .WithErrorCode(nameof(ErrorCodes.EM002));

            RuleFor(x => x.Since)
                .NotEmpty()
                    .WithMessage(ErrorCodes.EM001)
                    .WithErrorCode(nameof(ErrorCodes.EM001))

                .LessThan(DateTime.UtcNow)
                    .WithMessage(ErrorCodes.EM003)
                    .WithErrorCode(nameof(ErrorCodes.EM003))

                .WithName("Opening Date");

        }
    }
}
