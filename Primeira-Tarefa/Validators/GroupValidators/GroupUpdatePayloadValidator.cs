using FluentValidation;
using Primeira_Tarefa.DataBase;
using Primeira_Tarefa.Payloads.GroupPayloads;

namespace Primeira_Tarefa.Validators.GroupValidators
{
    public class GroupUpdatePayloadValidator : AbstractValidator<GroupUpdatePayload>
    {
        public GroupUpdatePayloadValidator(GroupDatabase groupDatabase)
        {
            RuleFor(x => x.GetId())
                .Must(x => groupDatabase.GroupList.Any(y => y.Id == x))
                    .WithMessage("The id provided has not yet been registered");

            RuleFor(x => x.Description)
                .NotEmpty()
                    .WithMessage("The description field cannot be empty")
                .MaximumLength(30)
                    .WithMessage("The description field cannot exceed 30 characters");
        }
    }
}
