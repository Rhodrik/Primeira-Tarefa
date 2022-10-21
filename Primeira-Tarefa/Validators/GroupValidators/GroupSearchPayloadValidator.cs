using FluentValidation;
using Primeira_Tarefa.Payloads.GroupPayloads;

namespace Primeira_Tarefa.Validators.GroupValidators
{
    public class GroupSearchPayloadValidator : AbstractValidator<GroupSearchPayload>
    {
        public GroupSearchPayloadValidator()
        {
            RuleFor(x => x.Description)
                .MaximumLength(30)
                .When(x => x.Description?.Length > 0);
        }
    }
}
