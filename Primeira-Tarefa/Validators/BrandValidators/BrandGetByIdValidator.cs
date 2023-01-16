using FluentValidation;
using Primeira_Tarefa.Errors;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Payloads.BrandPayloads;

namespace Primeira_Tarefa.Validators.BrandValidators
{
    public class BrandGetByIdValidator : AbstractValidator<BrandGetByIdPayload>
    {
        public BrandGetByIdValidator(IBrandRepository ibrandRepository)
        {
            RuleFor(x => x.GetId())
                .Must(x => x > 0)
                   .WithMessage(ErrorCodes.EM001)
                   .WithErrorCode(nameof(ErrorCodes.EM001))
                .MustAsync(async (x, token) => await ibrandRepository.IdExist(x))
                   .WithMessage(ErrorCodes.EM004)
                   .WithErrorCode(nameof(ErrorCodes.EM004));
        }
    }
}
