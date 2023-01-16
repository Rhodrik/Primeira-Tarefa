using FluentValidation;
using Primeira_Tarefa.Errors;
using Primeira_Tarefa.Payloads.GroupPayloads;

namespace Primeira_Tarefa.Validators.GroupValidators
{
    public class GroupInsertPayloadValidator : AbstractValidator<GroupInsertPayload>
    {
        public GroupInsertPayloadValidator()
        {
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
