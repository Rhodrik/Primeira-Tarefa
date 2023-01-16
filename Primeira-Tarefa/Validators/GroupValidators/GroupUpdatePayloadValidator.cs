using FluentValidation;
using Primeira_Tarefa.Errors;
using Primeira_Tarefa.Interfaces.Repositorys.Type_Repositorys;
using Primeira_Tarefa.Payloads.GroupPayloads;


namespace Primeira_Tarefa.Validators.GroupValidators
{
    public class GroupUpdatePayloadValidator : AbstractValidator<GroupUpdatePayload>
    {
        public GroupUpdatePayloadValidator(IGroupRepository igroupRepository)
        {
            RuleFor(x => x.GetId())
                .Must(x => x > 0)
                   .WithMessage(ErrorCodes.EM001)
                   .WithErrorCode(nameof(ErrorCodes.EM001))
                .MustAsync(async (x, token) => await igroupRepository.IdExist(x))
                   .WithMessage(ErrorCodes.EM004)
                   .WithErrorCode(nameof(ErrorCodes.EM004));

            RuleFor(x => x.Description)
                .NotEmpty()
                    .WithMessage(ErrorCodes.EM001)
                    .WithErrorCode(nameof(ErrorCodes.EM001))

                .MaximumLength(30)
                    .WithMessage(ErrorCodes.EM002)
                    .WithErrorCode(nameof(ErrorCodes.EM002));
        }
    }
}
