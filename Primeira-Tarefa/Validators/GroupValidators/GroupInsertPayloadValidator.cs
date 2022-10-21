using FluentValidation;
using Primeira_Tarefa.Payloads.GroupPayloads;

namespace Primeira_Tarefa.Validators.GroupValidators
{
    public class GroupInsertPayloadValidator : AbstractValidator<GroupInsertPayload>
    {
        public GroupInsertPayloadValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                    .WithMessage("The description field cannot be empty")

                .MaximumLength(30)
                    .WithMessage("The description field cannot exceed 30 characters");         
        }
    }
}
